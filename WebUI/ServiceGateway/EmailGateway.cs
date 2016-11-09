﻿using System;
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

        public IEnumerable<Theme> GetThemes()
        {
            HttpClient client = GetHttpClient();

            HttpResponseMessage response = client.GetAsync("api/themes/").Result;
            var themes = response.Content.ReadAsAsync<IEnumerable<Theme>>().Result;
            return themes;
        }

        public Email GetEmail(int id)
        {
            HttpClient client = GetHttpClient();

            HttpResponseMessage response = client.GetAsync("api/emails/" + id).Result;
            var email = response.Content.ReadAsAsync<Email>().Result;
            return email;
        }

        public Theme GetTheme(int id)
        {
            HttpClient client = GetHttpClient();

            HttpResponseMessage response = client.GetAsync("api/themes/" + id).Result;
            var theme = response.Content.ReadAsAsync<Theme>().Result;
            return theme;
        }

        //private HttpClient GetHttpClient()
        //{
        //    HttpClient client = new HttpClient();
        //    string baseAddress = WebConfigurationManager.AppSettings["CollaboratorDBAddress"];
        //    client.BaseAddress = new Uri(baseAddress);
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(
        //        new MediaTypeWithQualityHeaderValue("application/json")
        //    );

        //    //Create an Authorization header in order to authenticate as required
        //    // by the ProductStoreBLL REST Service.
        //    //string credentials = WebConfigurationManager.AppSettings["CollaboratorBLLRESTServiceCredentials"];
        //    //client.DefaultRequestHeaders.Authorization =
        //    //    new AuthenticationHeaderValue("Custom", credentials);

        //    return client;
        //}

    }
}