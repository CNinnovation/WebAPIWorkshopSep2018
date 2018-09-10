using ClientApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
                foreach (var book in books)
                {
                    Console.WriteLine($"{book.Title} {book.Publisher}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"exception of type {ex.GetType().Name} with message {ex.Message}");
            }
        }

        public async Task AddBookAsync(string uri, Book book)
        {
            try
            {
                string json = JsonConvert.SerializeObject(book);
                HttpContent jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage resp = await _httpClient.PostAsync(uri, jsonContent);
                resp.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"exception of type {ex.GetType().Name} with message {ex.Message}");
            }
        }
    }
}
