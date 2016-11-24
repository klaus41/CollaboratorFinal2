using System.Collections.Generic;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json.Linq;

namespace WebUI.ServiceGateway
{
    public class UserAccesGateway : GatewayClient
    {

        public HttpResponseMessage Login(string userName, string password)
        {
            HttpClient client = GetHttpClient();
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