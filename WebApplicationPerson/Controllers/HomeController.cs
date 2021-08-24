using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationPerson.Models;


namespace WebApplicationPerson.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        /*public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        /*public IActionResult Index()
        {
            return View();
        }*/

        public ViewResult Index() {
            return View("RsvpForm");

        }

        [HttpGet]
        public ViewResult RsvpForm() {
            return View();

        }
        [HttpPost]
        public ViewResult RsvpForm(Person person)
        {
            var allpfr = new PFRSumm
            {
                FirstName = person.FirstName,
                SecondName = person.SecondName,
                MiddleName = person.MiddleName,
                DateBirth = person.DateBirth,
                Snils = person.Snils,
                Summa = 0,
                Period = "",
                Counter = 0
            };
            using (var db = new ApplicationContext())
            {
                var pfrs = db.PFRStorages.Where(s => s.SnilsPFR == person.Snils).ToList();
                allpfr.Counter = pfrs.Count; 
                if (pfrs.Count > 0)
                {
                    foreach (var item in pfrs)
                    {
                        allpfr.Summa = item.Summa;
                        allpfr.Period = item.Period;
                    }
                }
            }
            return View("Thanks", allpfr);

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
