using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BSAF.Entity;
using BSAF.Helper;
using BSAF.Models;
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

            if (!string.IsNullOrWhiteSpace(this.txtUserName.Text) && !string.IsNullOrWhiteSpace(this.txtPassword.Text))
            {
               var isAuth =  UserController.Login(this.txtUserName.Text,this.txtPassword.Text);
                var username = this.txtUserName.Text; var password = this.txtPassword.Text;
                try
                {
                    var user = await userManager.FindByNameAsync(username);
                    if(user == null)
                    {
                        lblLoginMessage.Text = "Invalid username.";
                        lblLoginMessage.Visible = true;
                        return;
                    }
                    var result = await userManager.CheckPasswordAsync(user, password);
                    if (result)
                    {
                        var loginUser = userManager.Users.FirstOrDefault(u => u.UserName == username);
                        UserInfo.ID = loginUser.Id;
                        UserInfo.UserName = loginUser.UserName;
                        UserInfo.CenterCode = db.AspNetUsers.Where(u => u.Id == loginUser.Id).Select(u => u.UserName).FirstOrDefault();
                        MDIParent mdi = new MDIParent();
                        mdi.Show();
                        mdi.Owner = this;
                        this.Hide();
                    }
                    else {
                        lblLoginMessage.Text = "Invalid password";
                        lblLoginMessage.Visible = true;
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    lblLoginMessage.Text = "Can not process user login please try again.";
                    lblLoginMessage.Visible = true;
                    return;
                }
            }
        }

        private void Login_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
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
