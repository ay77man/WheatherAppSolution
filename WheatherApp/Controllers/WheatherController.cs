using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using WheatherApp.Models;

namespace WheatherApp.Controllers
{
    public class WheatherController : Controller
    {
        List<CityWeather> cityWeatherList = new List<CityWeather>
        {
            new CityWeather{CityUniqueCode = "LDN", CityName = "London", DateAndTime = DateTime.Parse("2030-01-01 8:00"),  TemperatureFahrenheit = 33},
            new CityWeather{CityUniqueCode = "NYC", CityName = "London", DateAndTime = DateTime.Parse("2030-01-01 3:00"),  TemperatureFahrenheit = 60},
            new CityWeather{CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = DateTime.Parse("2030-01-01 9:00"),  TemperatureFahrenheit = 82}
        };

        [Route("/")]
        [Route("Home")]
        public IActionResult Home()
        {
            return View(cityWeatherList);
        }
        [Route("Wheather/{CityUniqueCode}")]
        public IActionResult Details(string? CityUniqueCode)
        {
            if(CityUniqueCode == null)
            {
                return Content("InValid CityUniqueCode");
            }
            CityWeather? MatchedCityWeather = cityWeatherList.Where(temp=>temp.CityUniqueCode== CityUniqueCode).FirstOrDefault();
            return View(MatchedCityWeather);
        }
    }
}
