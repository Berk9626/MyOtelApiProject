using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Collections.Generic;
using RapidApiConsume.Web.Models;
using Newtonsoft.Json;

namespace RapidApiConsume.Web.Controllers
{
    public class ImdbController : Controller
    {
        List<ApiViewModel> _apiViewModels= new List<ApiViewModel>();
        public async Task<IActionResult> Index()
        {
            
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
                {
        { "X-RapidAPI-Key", "3828fda50cmsh4d895d5083cc471p1a6123jsn828950289755" },
        { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                _apiViewModels = JsonConvert.DeserializeObject<List<ApiViewModel>>(body);
                return View(_apiViewModels);
            }
       
        }
    }
}
