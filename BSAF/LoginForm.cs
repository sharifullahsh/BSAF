using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BSAF.Entity;
using BSAF.Helper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BSAF
{
    public partial class LoginForm : Form
    {
        UserManager<IdentityUser> userManager;

        public LoginForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(new IdentityDbContext("BSAFconn")));
        }
        //public bool VerifyUserNamePassword(string userName, string password)
        //{
           
        //    var testid = usermanager.Users.Where(u=>u.UserName=="khan1@gmail.com").Select(u=>u.Id).FirstOrDefault();
        //    return 
        //}
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            dbContext db = new dbContext();
            this.pbLoginProcess.Visible = true;
            if (!string.IsNullOrWhiteSpace(this.txtUserName.Text) && !string.IsNullOrWhiteSpace(this.txtPassword.Text))
            {
                var isAuth = UserController.Login(this.txtUserName.Text, this.txtPassword.Text);
                var username = this.txtUserName.Text; var password = this.txtPassword.Text;
                try
                {
                    var user = await userManager.FindByNameAsync(username);
                    if (user == null)
                    {
                        lblLoginMessage.Text = "Invalid username.";
                        lblLoginMessage.Visible = true;
                        this.pbLoginProcess.Visible = false;
                        return;
                    }
                    var result = await userManager.CheckPasswordAsync(user, password);
                    if (result)
                    {
                        var loginUser = userManager.Users.FirstOrDefault(u => u.UserName == username);
                        UserInfo.ID = loginUser.Id;
                        UserInfo.UserName = loginUser.UserName;
                        UserInfo.UserPassword = this.txtPassword.Text;
                        UserInfo.StationCode = db.AspNetUsers.Where(u => u.Id == loginUser.Id).Select(u => u.UserName).FirstOrDefault();

                        BSAFMDIParent mdi = new BSAFMDIParent();
                        Form frm = (Form)this.MdiParent;
                        MenuStrip ms = (MenuStrip)frm.Controls["menuStrip"];
                        ms.Enabled = true;
                        this.Dispose();
                    }
                    else
                    {
                        lblLoginMessage.Text = "Invalid password";
                        lblLoginMessage.Visible = true;
                        this.pbLoginProcess.Visible = false;
                        return;
                    }
                }
                catch (Exception ex)
                {
                    this.pbLoginProcess.Visible = false;
                    lblLoginMessage.Text = "Can not process user login please try again.";
                    lblLoginMessage.Visible = true;
                    return;
                }
            }
            else
            {
                lblLoginMessage.Visible = true;
                this.lblLoginMessage.Text = "Please enter username and password.";
                this.pbLoginProcess.Visible = false;
            }
        }

        private void Login_Click(object sender, EventArgs e)
        {

        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.lblLoginMessage.Visible = false;
            this.lblLoginMessage.Text = string.Empty;
        }


        //public IdentityResult CreateUser(string userName, string password)
        //{
        //    var usermanager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(new IdentityDbContext("BSAFconn")));
        //    var user = new IdentityUser { UserName = userName, Email = userName };
        //    return usermanager.Create(user, password);
        //}
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    var u = txtUserName.Text; var p = txtPassword.Text;
        //    try
        //    {
        //        var t = CreateUser(u, p);
        //        var errores = "";
        //        var err = t.Errors.ToList();
        //        t.Errors.ToList().ForEach(x => errores += x + Environment.NewLine);
        //        MessageBox.Show(t.ToString() + errores);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
    }
}
