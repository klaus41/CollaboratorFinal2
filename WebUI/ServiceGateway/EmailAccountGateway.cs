using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using WebUI.Models;

namespace WebUI.ServiceGateway
{
    public class EmailAccountGateway : GatewayClient
    {
        public IEnumerable<EmailAccount> GetEmailAccounts()
        {
            AddAuthorizationHeader();

            HttpClient client = GetHttpClient();

            HttpResponseMessage response = client.GetAsync("api/EmailAccounts/").Result;
            var emailAccounts = response.Content.ReadAsAsync<IEnumerable<EmailAccount>>().Result;
            response.EnsureSuccessStatusCode();

            return emailAccounts;
        }

        public EmailAccount GetEmailAccount(int id)
        {
            AddAuthorizationHeader();

            HttpClient client = GetHttpClient();

            HttpResponseMessage response = client.GetAsync("api/EmailAccounts/" + id).Result;
            var emailAccount = response.Content.ReadAsAsync<EmailAccount>().Result;
            response.EnsureSuccessStatusCode();

            return emailAccount;
        }

        public HttpResponseMessage Create(EmailAccount emailAccount)
        {
            AddAuthorizationHeader();

            HttpClient client = GetHttpClient();

            HttpResponseMessage response = client.PostAsJsonAsync("api/EmailAccounts/", emailAccount).Result;

            return response;
        }

        public HttpResponseMessage Edit(EmailAccount emailAccount)
        {
            AddAuthorizationHeader();

            HttpClient client = GetHttpClient();
            HttpResponseMessage response = client.PutAsJsonAsync("api/EmailAccounts/" + emailAccount.ID.ToString(), emailAccount).Result;

            return response;
        }

        public HttpResponseMessage Delete(int id)
        {
            AddAuthorizationHeader();

            HttpClient client = GetHttpClient();
            HttpResponseMessage response = client.DeleteAsync("api/EmailAccounts/" + id.ToString()).Result;

            return response.EnsureSuccessStatusCode();
        }
    }
}