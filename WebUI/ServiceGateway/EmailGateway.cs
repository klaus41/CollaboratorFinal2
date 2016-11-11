using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Configuration;
using WebUI.Models;
using WebUI.ServiceGateway;

namespace Webui.ServiceGateway
{
    public class EmailGateway : GatewayClient
    {
        public IEnumerable<Email> GetEmails()
        {
            HttpClient client = GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/emails/").Result;
            var emails = response.Content.ReadAsAsync<IEnumerable<Email>>().Result;
            return emails;
        }

        public Email GetEmail(int id)
        {
            HttpClient client = GetHttpClient();

            HttpResponseMessage response = client.GetAsync("api/emails/" + id).Result;
            var email = response.Content.ReadAsAsync<Email>().Result;
            return email;
        }


    }
}