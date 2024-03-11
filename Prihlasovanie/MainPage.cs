using System;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Linq;

namespace Prihlasovanie
{
    public partial class MainPage : Form
    {
        SQLiteConnection sqlite_conn;
        DataHandler dh = new DataHandler();
        User currentUser;
        bool clickedButton = false;

        public MainPage(User user)
        {
            InitializeComponent();
            sqlite_conn = new SQLiteConnection("Data Source=database.db; Version=3; New=True; Compress=True;");
            sqlite_conn.Open(); // Open the connection
            CreateTable(); // Create table if it doesn't exist

            currentUser = user;
            RefreshListBox();
            label2.Text += " " + user.UserName;
        }

        private void CreateTable()
        {
            // Create a table to store user data if it doesn't exist
            SQLiteCommand createTableCmd = sqlite_conn.CreateCommand();
            createTableCmd.CommandText = "CREATE TABLE IF NOT EXISTS Users (UserName TEXT, Password TEXT, IsAdmin INTEGER)";
            createTableCmd.ExecuteNonQuery();
        }

        private void ShowUsersData()
        {
            if (listBox1.SelectedIndex >= 0)
            {
                string selectedUsername = listBox1.SelectedItem.ToString();
                var selected = GetUserByUsername(selectedUsername);

                if (selected != null)
                {
                    txtBoxUserName.Text = selected.UserName;
                    if (!currentUser.isAdmin)
                    {
                        checkBoxIsAdmin.Visible = false;
                    }
                    else
                    {
                        checkBoxIsAdmin.Enabled = true;
                        checkBoxIsAdmin.Checked = selected.isAdmin;
                    }
                }
            }
            else if (!clickedButton)
            {
                MessageBox.Show("No object is selected");
            }
            else
            {
                clickedButton = false;
            }
        }

        private User GetUserByUsername(string username)
        {
            SQLiteCommand selectCmd = sqlite_conn.CreateCommand();
            selectCmd.CommandText = "SELECT * FROM Users WHERE UserName = @username";
            selectCmd.Parameters.AddWithValue("@username", username);

            using (SQLiteDataReader reader = selectCmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new User
                    {
                        UserName = reader["UserName"].ToString(),
                        Password = reader["Password"].ToString(),
                        isAdmin = Convert.ToBoolean(reader["IsAdmin"])
                    };
                }
            }

            return null;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowUsersData();
        }

        private void RefreshListBox()
        {
            listBox1.Items.Clear();
            if (currentUser.isAdmin)
            {
                SQLiteCommand selectCmd = sqlite_conn.CreateCommand();
                selectCmd.CommandText = "SELECT UserName FROM Users";

                using (SQLiteDataReader reader = selectCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader["UserName"].ToString());
                    }
                }
            }
            else
            {
                listBox1.Items.Add(currentUser.UserName);
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0 || txtBoxNewPassword.Text != "")
            {
                string selectedUsername = listBox1.SelectedItem.ToString();
                var existingContact = GetUserByUsername(selectedUsername);

                if (existingContact != null)
                {
                    string newPassword = txtBoxNewPassword.Text;
                    string hashPassword = dh.HashPassword(newPassword);

                    SQLiteCommand updateCmd = sqlite_conn.CreateCommand();
                    updateCmd.CommandText = "UPDATE Users SET Password = @password, IsAdmin = @isAdmin WHERE UserName = @username";
                    updateCmd.Parameters.AddWithValue("@password", hashPassword);
                    updateCmd.Parameters.AddWithValue("@isAdmin", currentUser.isAdmin ? 1 : 0);
                    updateCmd.Parameters.AddWithValue("@username", existingContact.UserName);
                    updateCmd.ExecuteNonQuery();

                    MessageBox.Show("Updated");
                    RefreshListBox();
                }
                else
                {
                    MessageBox.Show("You typed something wrong");
                }
            }
            else
            {
                MessageBox.Show("No user selected or Password is empty");
            }
        }

        private void LoginPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            sqlite_conn.Close(); // Close the connection when the form is closing
            Application.Exit();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            sqlite_conn.Close(); // Close the connection when logging out
            Login login = new Login();
            login.FormClosed += LoginPage_FormClosed;
            login.Show();
            this.Hide();
        }
    }
}
