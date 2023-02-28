using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class Class2
    {
        private int id = 4;
        private string token = "QpwL5tke4Pnpja7X4";

        public void name()
        {
            RestClient client = new RestClient("https://reqres.in/");

            RestRequest request = new RestRequest("api/register", Method.POST);
            Registration reg = new Registration("eve.holt@reqres.in", "pistol");
            //request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(reg);

            IRestResponse response = client.Post(request);
            Console.WriteLine(response);
        }
    }
}
