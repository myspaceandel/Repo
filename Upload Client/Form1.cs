using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Upload_Client
{
    public partial class Form1 : Form
    {
        string session_id;
        public Form1()
        {
            InitializeComponent();
            
        }
        private void btn_get_token_Click(object sender, EventArgs e)
        {
            //session_id = API_functions.Login(t_username.Text, t_password.Text);
            session_id = API_functions.Login("volkofrap@gmail.com", "15RSuheggf");
            if (session_id != "")
            {
                MessageBox.Show("You have been successfully logged!");
            }
            else
            {
                MessageBox.Show("You have some errors! Please try again.");
            }
        }
        #region Placeholders
        private void t_username_Enter(object sender, EventArgs e)
        {
            if (t_username.Text == "Username")
            {
                t_username.Text = "";
            }
        }

        private void t_username_Leave(object sender, EventArgs e)
        {
            if (t_username.Text == "")
            {
                t_username.Text = "Username";
            }
        }

        private void t_password_Enter(object sender, EventArgs e)
        {
            if (t_password.Text == "Password")
            {
                t_password.Text = "";
            }
        }

        private void t_password_Leave(object sender, EventArgs e)
        {
            if (t_password.Text == "")
            {
                t_password.Text = "Password";
            }
        }

        #endregion

        private void btn_upload_Click(object sender, EventArgs e)
        {
            API_functions.Upload("", 0, session_id);
        }
    }
}
