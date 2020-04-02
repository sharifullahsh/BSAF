using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BSAF.Helper
{
    public class UserController
    {
        private string baseUrl;
        public UserController()
        {
            this.baseUrl = ConfigurationManager.AppSettings["apiBaseUrl"].ToString();
        }
        public UserInfo AuthenticateUser(string username, string password)
        {
            string endpoint = this.baseUrl + "/Login/login";
            string method = "POST";
            string json = JsonConvert.SerializeObject(new
            {
                Username = username,
                Password = password
            });

            WebClient wc = new WebClient();
            wc.Headers["Content-Type"] = "application/json";
            try
            {
                string response = wc.UploadString(endpoint, method, json);
                return JsonConvert.DeserializeObject<UserInfo>(response);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //public UserInfo GetUserDetails(UserInfo user)
        //{
        //    string endpoint = this.baseUrl + "/users/" + user.Id;
        //    string access_token = UserInfo.access_token;

        //    WebClient wc = new WebClient();
        //    wc.Headers["Content-Type"] = "application/json";
        //    wc.Headers["Authorization"] = access_token;
        //    try
        //    {
        //        string response = wc.DownloadString(endpoint);
        //        user = JsonConvert.DeserializeObject<User>(response);
        //        user.access_token = access_token;
        //        return user;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

        //public User RegisterUser(string username, string password, string firstname,
        //    string lastname, string middlename, int age)
        //{
        //    string endpoint = this.baseUrl + "/users";
        //    string method = "POST";
        //    string json = JsonConvert.SerializeObject(new
        //    {
        //        username = username,
        //        password = password,
        //        firstname = firstname,
        //        lastname = lastname,
        //        middlename = middlename,
        //        age = age
        //    });

        //    WebClient wc = new WebClient();
        //    wc.Headers["Content-Type"] = "application/json";
        //    try
        //    {
        //        string response = wc.UploadString(endpoint, method, json);
        //        return JsonConvert.DeserializeObject<User>(response);
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}
    }
}
