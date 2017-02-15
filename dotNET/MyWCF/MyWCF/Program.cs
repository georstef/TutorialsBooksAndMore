using System;
using System.Net.Http;

namespace MyWCF
{
    class Program
    {
        static void Main(string[] args)
        {
            var baseAddress = new Uri("http://localhost:8733/myWCFLibrary/Math/api/");
            var serviceName = "Add";
            var parameters = "num1=1&num2=3";
            try
            {
                using (var client = new HttpClient() { BaseAddress = baseAddress })
                {
                    //if (!string.IsNullOrEmpty(Guid))
                    //{
                    //    client.DefaultRequestHeaders.Add("token", Guid);
                    //}

                    HttpResponseMessage response = client.GetAsync($"{serviceName}/{parameters}").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var responseJson = response.Content.ReadAsStringAsync().Result;
                        //return Newtonsoft.Json.JsonConvert.DeserializeObject<string>(responseJson);
                        Console.WriteLine(responseJson);
                    }
                    else
                    {
                        throw new Exception("Service επεστρεψε HTTP κωδικό: " + response.ToString() + "\n" + response.RequestMessage);
                    }
                }
            }
            catch (Exception exc)
            {
                //Log.Error(exc, "Συνέβη σφάλμα κατα την κλήση του web service.");
                Console.WriteLine(exc.Message + "\n" + exc.StackTrace);
            }
            Console.ReadKey();
        }
    }
}
