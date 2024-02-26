using System.Windows.Forms;
using System;
using System.Linq;

namespace Prihlasovanie
{
    public partial class MainPage : Form
    {
        DataHandler dh = new DataHandler();
        User currentUser;
        bool clickedButton = false;

        public MainPage(User user)
        {
            dh.DataLoad();
            InitializeComponent();
            currentUser = user;
            RefreshListBox();
            label2.Text += " " + user.UserName;
        }

        private void ShowUsersData()
        {
            if (listBox1.SelectedIndex >= 0)
            {
                string selectedUsername = listBox1.SelectedItem.ToString();
                var selected = dh.users.FirstOrDefault(u => u.UserName == selectedUsername);

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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowUsersData();
        }

        private void RefreshListBox()
        {
            listBox1.Items.Clear();
            if (currentUser.isAdmin)
            {
                foreach (User item in dh.users)
                {
                    listBox1.Items.Add(item.UserName);
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
                var existingContact = dh.users.FirstOrDefault(u => u.UserName == selectedUsername);

                if (existingContact != null)
                {
                    var hashPassword = dh.HashPassword(txtBoxNewPassword.Text);
                    existingContact.UserName = txtBoxUserName.Text;
                    existingContact.Password = hashPassword;

                    if (currentUser.isAdmin || existingContact == currentUser)
                    {
                        existingContact.isAdmin = checkBoxIsAdmin.Checked;
                    }
                    dh.SaveData();
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
            Application.Exit();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.FormClosed += LoginPage_FormClosed;
            login.Show();
            this.Hide();
        }
    }
}
