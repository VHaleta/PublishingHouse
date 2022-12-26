using PublishingHouse.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PublishingHouse
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            textBoxPassword.PasswordChar= '*';
            textBoxPassword.UseSystemPasswordChar= true;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            Login loging = Database.logins.FirstOrDefault(x => x.Username == username && x.Password == x.Password);
            if (loging == null)
            {
                labelInfo.Text = "Wrong login or password";
                textBoxPassword.Text = "";
                return;
            }
            Session.IDph = loging.Id;

            MainForm mainForm = new MainForm();
            Hide();
            mainForm.ShowDialog();
            try
            {
                Show();
                textBoxUsername.Text = "";
                textBoxPassword.Text = "";
            }
            catch(Exception ex)
            { 
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
