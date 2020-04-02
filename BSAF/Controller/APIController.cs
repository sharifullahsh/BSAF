﻿using BSAF.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using BSAF.Models.ViewModels;

namespace BSAF.Controller
{
    public class APIController
    {
        public APIController()
        {
            
        }

        public static bool SubmitBeneficiary(BeneficiaryVM model)
        {
            string endpoint = Variables.baseUrl + "/Beneficiary/";
            string method = "POST";
            string json = JsonConvert.SerializeObject(model);
            WebClient wc = new WebClient();
            wc.Headers["Content-Type"] = "application/json";
            wc.Headers["Authorization"] = UserInfo.token;
            try
            {
                string response = wc.UploadString(endpoint, method, json);
                return JsonConvert.DeserializeObject<bool>(response);
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
