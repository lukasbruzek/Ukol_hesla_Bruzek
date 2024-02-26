using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Prihlasovanie
{
    public partial class Login : Form
    {
        DataHandler dh = new DataHandler();
        public Login()
        {
            InitializeComponent();
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
            dh.DataLoad();
            foreach (User user in dh.users)
            {
                if (user.UserName == txtBoxUserName.Text)
                {
                    if (VerifyPassword(txtBoxPassword.Text, user.Password))
                    {
                        MainPage mainPage = new MainPage(user);
                        mainPage.FormClosed += MainPage_FormClosed;
                        mainPage.Show();
                        login = true;
                        this.Hide();
                    }
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

