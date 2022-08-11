using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public class ConnectionFactory
    {
        public static IOrganizationService GetService()
        {
            string connectionString =
         "AuthType=OAuth;" +
         "Username=TeamRGE@TeamWork096.onmicrosoft.com;" +
         "Password=Caps1367@;" +
         "Url=https://org0b9f8446.crm2.dynamics.com/;" +
         "AppId=e8652024-cb1d-49bf-a391-78a949be265a;" +
         "RedirectUri=app://9896d91c-3ad3-4762-918f-3024bebc5d1a;";


            CrmServiceClient crmServiceClient = new CrmServiceClient(connectionString);

            return crmServiceClient.OrganizationWebProxyClient;
        }
    }
}
