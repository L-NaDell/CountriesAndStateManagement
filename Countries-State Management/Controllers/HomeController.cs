using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Countries_State_Management.Models;

namespace Countries_State_Management.Controllers
{
    public class HomeController : Controller
    {
        private static List<Country> _countries = new List<Country>();

        public HomeController()
        {
            if (_countries.Count == 0)
            {
                _countries.Add(new Country("USA", "English-ish", "Hello World!", "Located in North America, The United States of America is bordered on the west by the Pacific Ocean and to the east by the Atlantic Ocean. Along the northern border is Canada and the southern border is Mexico.", new List<string> { "red", "white", "blue" }));
                _countries.Add(new Country("Mexico", "Spanish", "Hola mundo!", "Mexico is a land of extremes, with high mountains and deep canyons in the center of the country, sweeping deserts in the north, and dense rain forests in the south and east.", new List<string> { "red", "white", "green" }));
                _countries.Add(new Country("Algeria", "Arabic and Berber", "Marhabaan bialealam", "Algeria is a country located in Northern Africa bordering the Mediterranean Sea. It is considered the gateway between Africa and Europe. Algeria is mostly desert with a few mountains and a narrow coastal plain.", new List<string> { "blue", "yellow", "red" }));
                _countries.Add(new Country("Sweden", "Swedish", "Hej världen!", "Sweden is a sparsely populated country, characterised by its long coastline, extensive forests and numerous lakes.", new List<string> { "blue", "gold" }));
                _countries.Add(new Country("Greece", "Greek", "Γειά σου Κόσμε!", "Greece has the longest coastline in Europe and is the southernmost country in Europe. The mainland has rugged mountains, forests, and lakes, but the country is well known for the thousands of islands dotting the blue Aegean Sea to the east, the Mediterranean Sea to the south, and the Ionian Sea to the west.", new List<string> { "blue", "white" }));
            }
        }
        public IActionResult Index()
        {
            return View(_countries);
        }
        public IActionResult Details(string country)
        {
            SetCountry(country);

            return View();
        }
        public IActionResult Description(string country)
        {
            SetCountry(country);

            return View();
        }

        private void SetCountry(string country)
        {
            Country myCountry = _countries.FirstOrDefault(thisCountry => thisCountry.Name == country);

            TempData["country"] = country;
            TempData["language"] = myCountry.OfficialLanguages;
            TempData["description"] = myCountry.Description;
            TempData["greeting"] = myCountry.Greeting;
            TempData["colors"] = string.Join(", ", myCountry.Colors);
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
