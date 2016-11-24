using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using WebUI.Models;

namespace WebUI.ServiceGateway
{
    public class ThemeGateway : GatewayClient
    {

        public IEnumerable<Theme> GetThemes()
        {
            AddAuthorizationHeader();

            HttpClient client = GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/themes/").Result;
            var themes = response.Content.ReadAsAsync<IEnumerable<Theme>>().Result;
            return themes;
        }

        public Theme GetTheme(int id)
        {
            HttpClient client = GetHttpClient();

            HttpResponseMessage response = client.GetAsync("api/themes/" + id).Result;

            response.EnsureSuccessStatusCode();

            var theme = response.Content.ReadAsAsync<Theme>().Result;
            return theme;
       }

        public HttpResponseMessage Create(Theme theme)
        {
            HttpClient client = GetHttpClient();

            HttpResponseMessage response = client.PostAsJsonAsync("api/themes/", theme).Result;
            return response;
        }

        public HttpResponseMessage Edit(Theme theme)
        {
            HttpClient client = GetHttpClient();
            HttpResponseMessage response = client.PutAsJsonAsync("api/themes/" + theme.ID.ToString(), theme).Result;
            return response;
        }

        public HttpResponseMessage Delete(int id)
        {
            HttpClient client = GetHttpClient();
            HttpResponseMessage response = client.DeleteAsync("api/themes/" + id.ToString()).Result;
            return response.EnsureSuccessStatusCode();
        }
    }
}