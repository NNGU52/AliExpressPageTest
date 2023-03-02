using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassLibrary5
{
    public class Class5
    {
        public string PutMethod()
        {
            RestClient client = new RestClient("https://reqres.in/");
            RestRequest request = new RestRequest("/api/users/2", Method.PUT);
            UpdateDate updateDate = new UpdateDate("morpheus", "zion resident");
            request.AddJsonBody(updateDate);

            IRestResponse response = client.Execute(request);
            var content = response.Content;
            var updateDateNoJson = JsonConvert.DeserializeObject<ResultUpdateDate>(content);

            string s = Regex.Replace(updateDateNoJson.UpdatedAt.Date.ToString(), @"\s\d:\d{2}:\d{2}", "");

            return s;
        }
    }
}
