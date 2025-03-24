using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace Desktop_client
{
    internal class Postservice
    {
        static HttpClient client = new HttpClient();

        public void createConnection()
        {
            client.BaseAddress = new Uri("http://localhost:8082/");  
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public List<Post> GetPostsByKeyword(string keyword)
        {
            try
            {
                HttpResponseMessage response = client.GetAsync($"posts/search?keyword={keyword}").Result;

                if (response.IsSuccessStatusCode)
                {
                    string resultString = response.Content.ReadAsStringAsync().Result;
                    return JsonSerializer.Deserialize<List<Post>>(resultString);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return new List<Post>();
        }

        public List<Comment> GetCommentsByKeyword(string keyword)
        {
            try
            {
                HttpResponseMessage response = client.GetAsync($"comments/search?keyword={keyword}").Result;

                if (response.IsSuccessStatusCode)
                {
                    string resultString = response.Content.ReadAsStringAsync().Result;
                    return JsonSerializer.Deserialize<List<Comment>>(resultString);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return new List<Comment>();
        }
    }
}
