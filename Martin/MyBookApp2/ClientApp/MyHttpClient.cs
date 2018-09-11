using System;
using System.Net.Http;
using ClientApp.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace ClientApp
{
    public class MyHttpClient
    {
        private readonly HttpClient _httpClient;
        public MyHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        public async Task ShowAllBooksAsync(string uri)
        {
            try 
            {
                HttpResponseMessage resp = await _httpClient.GetAsync(uri);
                resp.EnsureSuccessStatusCode();
                string content = await resp.Content.ReadAsStringAsync();
                var books = JsonConvert.DeserializeObject<IEnumerable<Book>>(content);
                foreach (var book in books) {
                    Console.WriteLine($"{book.Title} {book.Publisher}");
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine($"execption of type {exp.GetType().Name} with message {exp.Message}");
            }
        }
    }
}
