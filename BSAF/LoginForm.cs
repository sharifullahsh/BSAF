using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            BSAFMainMDIForm mForm = new BSAFMainMDIForm();
            mForm.Show();
            mForm.Owner = this;
            this.Hide();
        }

        private void Login_Click(object sender, EventArgs e)
        {

        }

      
    }
}
