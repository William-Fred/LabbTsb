using LabbTsb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace LabbTsb.Controllers
{
    public class ApiController : Controller
    {
        private readonly ILogger<ApiController> _logger;

        public ApiController(ILogger<ApiController> logger)
        {
            _logger = logger;
        }

       
        //Hämta data från API
       public async Task<IActionResult> Index()
        {
            List<CitiesData> citiesList = new List<CitiesData>();
            using ( var HttpClient = new HttpClient())
            {
                using (var response = await HttpClient.GetAsync("http://localhost:33255/api/Cities"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    citiesList = JsonConvert.DeserializeObject<List<CitiesData>>(apiResponse);

                }
                return View(citiesList);
            }
        }
        //Lägga till ny stad i api
        public ViewResult AddCity() => View();
        [HttpPost]
        public async Task<IActionResult> AddCity(CitiesData cities)
        {
            try
            {

           
            CitiesData receivedCity = new CitiesData();
            using (var httpClient = new HttpClient())
            {
                //Eftersom datan skickas i Json format behöver vi använda oss av Jsonconvert.SerializeObject metoden på det vi skall skicka.
                StringContent content = new StringContent(JsonConvert.SerializeObject(cities), Encoding.UTF8, "application/json");
                using(var response = await httpClient.PostAsync("http://localhost:33255/api/Cities", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    receivedCity = JsonConvert.DeserializeObject<CitiesData>(apiResponse);
                }
            }
            return View(receivedCity);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return View();
            }
        }

        public async Task<IActionResult> UpdateCity(int id)
        {
            CitiesData cities = new CitiesData();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:33255/api/Cities/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cities = JsonConvert.DeserializeObject<CitiesData>(apiResponse);
                }
            }
            return View(cities);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCity(CitiesData cities)
        {
            CitiesData receivedCity = new CitiesData();
            using(var httpClient = new HttpClient())
            {
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(cities.CitiesId.ToString()), "CitiesId");
                content.Add(new StringContent(cities.CityName), "CityName");
                content.Add(new StringContent(cities.ZipCode), "ZipCode");
                content.Add(new StringContent(cities.CountryName), "CountryName");

                using (var response = await httpClient.PutAsync("http://localhost:33255/api/Cities", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "All good!";
                    receivedCity = JsonConvert.DeserializeObject<CitiesData>(apiResponse);
                }
            }
            return View(receivedCity);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
