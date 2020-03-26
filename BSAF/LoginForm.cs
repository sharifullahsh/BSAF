using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BSAF.Helper;

namespace BSAF
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.txtUserName.Text) && !string.IsNullOrWhiteSpace(this.txtPassword.Text))
            {
               var isAuth =  UserController.Login(this.txtUserName.Text,this.txtPassword.Text);
            }
            //this.UserController.
            MDIParent mdi = new MDIParent();
            mdi.Show();
            mdi.Owner = this;
            this.Hide();
        }

        private void Login_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
