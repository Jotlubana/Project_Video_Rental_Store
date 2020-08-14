using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoRentalStore
{
    public partial class LoginRegisterForm : Form
    {
        public LoginRegisterForm()
        {
            InitializeComponent();
        }

        ManageLoginRegister loginManagerObject = new ManageLoginRegister();
        private void Button1_Click(object sender, EventArgs e)
        {
            if(loginManagerObject.Login(tbUsername.Text,tbPassword.Text))
            {
                new frmMain().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("check username and password","Error");
            }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            if(tbUsername.Text!="" && tbPassword.Text!="")
            {
                string username = Convert.ToString(tbUsername.Text);
                string password = Convert.ToString(tbPassword.Text);
                if(loginManagerObject.Register(username, password))
                {
                    MessageBox.Show("Registered successfully", "Success");
                }else
                {
                    MessageBox.Show("User already registered.");
                }
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
