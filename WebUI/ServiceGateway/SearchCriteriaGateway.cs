using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using WebUI.Models;

namespace WebUI.ServiceGateway
{
    public class SearchCriteriaGateway : GatewayClient
    {


        public IEnumerable<SearchCriteria> GetSearchCriterias()
        {
            HttpClient client = GetHttpClient();

            HttpResponseMessage response = client.GetAsync("api/SearchCriterias/").Result;
            var sc = response.Content.ReadAsAsync<IEnumerable<SearchCriteria>>().Result;
            return sc;
        }

        public SearchCriteria GetSearchCriteria(int id)
        {
            HttpClient client = GetHttpClient();

            HttpResponseMessage response = client.GetAsync("api/SearchCriterias/" + id).Result;
            var sc = response.Content.ReadAsAsync<SearchCriteria>().Result;
            return sc;
        }

        public HttpResponseMessage Create(SearchCriteria sc)
        {
            HttpClient client = GetHttpClient();

            HttpResponseMessage response = client.PostAsJsonAsync("api/SearchCriterias/", sc).Result;
            return response;
        }

        public HttpResponseMessage Edit(SearchCriteria sc)
        {
            HttpClient client = GetHttpClient();
            HttpResponseMessage response = client.PutAsJsonAsync("api/SearchCriterias/" + sc.ID.ToString(), sc).Result;
            return response;
        }

        public HttpResponseMessage Delete(int id)
        {
            HttpClient client = GetHttpClient();
            HttpResponseMessage response = client.DeleteAsync("api/SearchCriterias/" + id.ToString()).Result;
            return response.EnsureSuccessStatusCode();
        }

    }
}