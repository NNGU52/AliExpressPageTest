using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary4
{
    public class Class4
    {
        public int expectedCodeInt = 204;

        public int DeleteMethod()
        {
            RestClient client = new RestClient("https://reqres.in/");

            RestRequest request = new RestRequest("/api/users/2", Method.DELETE);
            IRestResponse response = client.Execute(request);
            var statusCodeString = response.StatusCode.ToString();
            var statusCodeInt = (int)response.StatusCode;

            return statusCodeInt;
        }
    }
}
