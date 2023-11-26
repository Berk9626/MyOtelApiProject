using HotelProject.WebUI.Dtos.ServiceDto;
using HotelProject.WebUI.Dtos.SubscribeDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }



        public IActionResult Index()
        {
            return View();
        }

        [HttpGet] 
        public PartialViewResult _SubscribePartialAsync()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> _SubscribePartialAsync(CreateSubscribeDto createsubsDto)
        {


            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createsubsDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
             await client.PostAsync("http://localhost:59815/api/Subscribe", content);
             return RedirectToAction("Index","Default");
            
            

        }

    }
}
