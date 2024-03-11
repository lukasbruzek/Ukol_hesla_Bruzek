using System;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Prihlasovanie
{
    public partial class Login : Form
    {
        SQLiteConnection sqlite_conn;
        public Login()
        {
            InitializeComponent();
            sqlite_conn = new SQLiteConnection("Data Source=database.db; Version=3; New=True; Compress=True;");
        }

        bool VerifyPassword(string enteredPassword, string storedHash)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(enteredPassword));

                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    stringBuilder.Append(hashBytes[i].ToString("x2"));
                }
                string enteredPasswordHash = stringBuilder.ToString();

                return enteredPasswordHash == storedHash;
            }
        }

        private void Login_Click(object sender, EventArgs e)
        {
            bool login = false;

            using (sqlite_conn)
            {
                sqlite_conn.Open();

                // Check if the user exists and verify the password
                SQLiteCommand checkUserCmd = sqlite_conn.CreateCommand();
                checkUserCmd.CommandText = "SELECT Password FROM Users WHERE UserName = @username";
                checkUserCmd.Parameters.AddWithValue("@username", txtBoxUserName.Text);
                string storedHash = checkUserCmd.ExecuteScalar() as string;

                if (storedHash != null && VerifyPassword(txtBoxPassword.Text, storedHash))
                {
                    MainPage mainPage = new MainPage(new User(txtBoxUserName.Text, "", false)); // Create a temporary User object for now
                    mainPage.FormClosed += MainPage_FormClosed;
                    mainPage.Show();
                    login = true;
                    this.Hide();
                }
            }

            if (!login)
            {
                MessageBox.Show("Wrong credentials");
            }
        }

        private void MainPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void newAccount_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.FormClosed += MainPage_FormClosed;
            register.Show();
            this.Hide();
        }
    }
}
