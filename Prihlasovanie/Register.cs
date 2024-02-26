using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Prihlasovanie
{
    public partial class Register : Form
    {
        DataHandler dh = new DataHandler();
        public Register()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (txtBoxPasswordOne.Text != txtBoxPasswordTwo.Text)
            {
                return;
            }
            bool isAdmin = false;
            dh.DataLoad();

            if (dh.users.Any(user => user.UserName == txtBoxUsername.Text))
            {
                MessageBox.Show("This user already exists");
            }
            else
            {
                if (dh.users.Count == 0)
                {
                    isAdmin = true;
                }
                string hashedPassword = dh.HashPassword(txtBoxPasswordOne.Text);
                dh.users.Add(new User(txtBoxUsername.Text, hashedPassword, isAdmin));
                dh.SaveData();
                MessageBox.Show("Saved");
                Login login = new Login();
                login.FormClosed += LoginPage_FormClosed;
                login.Show();
                this.Hide();
            }
        }

        private void LoginPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
