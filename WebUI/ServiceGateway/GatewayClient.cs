using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Configuration;
using Newtonsoft.Json.Linq;

namespace WebUI.ServiceGateway
{
    public class GatewayClient
    {
        HttpClient client = new HttpClient();
        public GatewayClient()
        {
            string baseAddress = WebConfigurationManager.AppSettings["CollaboratorDBAddress"];
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public HttpClient GetHttpClient()
        {
            //
            //string baseAddress = WebConfigurationManager.AppSettings["CollaboratorDBAddress"];
            //client.BaseAddress = new Uri(baseAddress);
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")
            //);

            //Create an Authorization header in order to authenticate as required
            //string credentials = baseAddress; //WebConfigurationManager.AppSettings["CollaboratorDBAddress"];
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Custom", credentials);


            return client;
        }

        internal void AddAuthorizationHeader()
        {

            if (HttpContext.Current.Session["token"] != null)
            {
                string token = HttpContext.Current.Session["token"].ToString();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            }
        }

        public HttpResponseMessage Login(string userName, string password)
        {
            //setup login data
            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", userName),
                new KeyValuePair<string, string>("password", password)
            });

            //Request token
            HttpResponseMessage response = client.PostAsync("/token", formContent).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseJson = response.Content.ReadAsStringAsync().Result;
                var jObject = JObject.Parse(responseJson);
                string token = jObject.GetValue("access_token").ToString();
                HttpContext.Current.Session["token"] = token;
            }

            return response;
        }
    }
}