using System.Collections.Generic;
using System.Net.Http;
using WebUI.Models;
using WebUI.ServiceGateway;

namespace Webui.ServiceGateway
{
    public class EmailGateway : GatewayClient
    {
        public IEnumerable<Email> GetEmails()
        {
            AddAuthorizationHeader();

            HttpClient client = GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/emails/").Result;
            response.EnsureSuccessStatusCode();
            var emails = response.Content.ReadAsAsync<IEnumerable<Email>>().Result;
            return emails;
        }

        public Email GetEmail(int id)
        {
            AddAuthorizationHeader();

            HttpClient client = GetHttpClient();

            HttpResponseMessage response = client.GetAsync("api/emails/" + id).Result;
            response.EnsureSuccessStatusCode();

            var email = response.Content.ReadAsAsync<Email>().Result;
            return email;
        }


    }
}