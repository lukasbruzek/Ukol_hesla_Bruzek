using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Prihlasovanie
{
    public partial class Register : Form
    {
        SQLiteConnection sqlite_conn;
        DataHandler dh = new DataHandler();
        public Register()
        {
            InitializeComponent();
            sqlite_conn = new SQLiteConnection("Data Source=database.db; Version=3; New=True; Compress=True;");
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (txtBoxPasswordOne.Text != txtBoxPasswordTwo.Text)
            {
                MessageBox.Show("Passwords don't match");
                return;
            }

            using (sqlite_conn)
            {
                sqlite_conn.Open();

                // Check if the user already exists
                SQLiteCommand checkUserCmd = sqlite_conn.CreateCommand();
                checkUserCmd.CommandText = "SELECT COUNT(*) FROM Users WHERE UserName = @username";
                checkUserCmd.Parameters.AddWithValue("@username", txtBoxUsername.Text);
                int count = Convert.ToInt32(checkUserCmd.ExecuteScalar());

                if (count > 0)
                {
                    MessageBox.Show("This user already exists");
                    return;
                }

                // Insert new user data
                SQLiteCommand insertCmd = sqlite_conn.CreateCommand();
                insertCmd.CommandText = "INSERT INTO Users (UserName, Password, IsAdmin) VALUES (@username, @password, @isAdmin)";
                insertCmd.Parameters.AddWithValue("@username", txtBoxUsername.Text);
                insertCmd.Parameters.AddWithValue("@password", dh.HashPassword(txtBoxPasswordOne.Text));
                insertCmd.Parameters.AddWithValue("@isAdmin", dh.users.Count == 0 ? 1 : 0); // Set IsAdmin to 1 if it's the first user, 0 otherwise
                insertCmd.ExecuteNonQuery();

                MessageBox.Show("User registered successfully");
                string currentDirectory = Environment.CurrentDirectory;
                MessageBox.Show("Current directory: " + currentDirectory);

                // Close the form or take any other necessary action
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }
    }
}
