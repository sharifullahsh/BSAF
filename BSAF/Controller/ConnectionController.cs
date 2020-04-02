using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Configuration;
using BSAF.Helper;

namespace BSAF.Controller
{
    public class ConnectionController
    {

    public static bool IsConnectedToInternet()
        {
            string host = Variables.baseUrl;
            bool result = false;
            Ping p = new Ping();
            try
            {
                PingReply reply = p.Send(host, 3000);
                if (reply.Status == IPStatus.Success)
                    return true;
            }catch(Exception e)
             {
                
            }
            return result;
        }
}
}
