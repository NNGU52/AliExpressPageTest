using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary3
{
    public class Class3
    {
        public int statusCodeInt;
        public int expectedCodeInt = 200;

        public List<int> Years()
        {
            RestClient client = new RestClient("https://reqres.in/");

            RestRequest request = new RestRequest("api/unknown", Method.GET);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            var statusCodeString = response.StatusCode.ToString();
            var statusCodeInt = (int)response.StatusCode;
            var users = JsonConvert.DeserializeObject<ListResource>(content);
            List<int> years = new List<int>();

            for (int i = 0; i < users.data.Count; i++)
            {
                years.Add(users.data[i].year);
            }

            return years;
        }
    }
}
