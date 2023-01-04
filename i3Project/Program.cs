using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace i3Project
{
    public class DataObject
    {
        public string Name { get; set; }
    }

    internal class Program
    {
        private const string URL = "http://echo.jsontest.com/key/value/one/two";

        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            try
            {
                var HttpResponseMessage = await httpClient.GetAsync(URL);

                string jsonResponse = await HttpResponseMessage.Content.ReadAsStringAsync();
                if(jsonResponse != null)
                {
                    Console.WriteLine(jsonResponse);
                }

                //var A = JsonConvert.DeserializeObject<List<Post>>(jsonResponse);

                var myPosts = JsonConvert.DeserializeObject<Post[]>(jsonResponse);

                foreach (var post in myPosts)
                {
                    Console.WriteLine($"{post.One} {post.Key}");
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(URL);

            //// Add an Accept header for JSON format.
            //client.DefaultRequestHeaders.Accept.Add(
            //new MediaTypeWithQualityHeaderValue("application/json"));

            //// List data response.
            //HttpResponseMessage response = client.GetAsync(URL).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            //if (response.IsSuccessStatusCode)
            //{
            //    // Parse the response body.
            //    //var dataObjects = response.Content.ReadAsAsync<IEnumerable<DataObject>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
            //    //foreach (var d in dataObjects)
            //    //{
            //    //    Console.WriteLine("{0}", d.Name);
            //    //}
            //}
            //else
            //{
            //    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            //}

            //// Make any other calls using HttpClient here.

            //// Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            //client.Dispose();

        }
    }
}
