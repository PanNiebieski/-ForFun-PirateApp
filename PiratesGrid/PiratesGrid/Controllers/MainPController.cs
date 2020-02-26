using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PirateApp.BussinesLogic;
using PirateApp.Domain;
using PiratesGrid.ViewModel;

namespace PiratesGrid.Controllers
{
    //[Route("")]
    public class MainPController : Controller
    {
        private IPirateService _pirateService;

        private readonly IOptions<PiratesGridOptions> _options;

        public MainPController(IPirateService pirateService,
            IOptions<PiratesGridOptions> options)
        {
            _pirateService = pirateService;
            _options = options;
        }

        //[Route("")]
        public IActionResult Index()
        {
            ViewBag.Title = _options.Value.WebSiteName;


            var pirates = _pirateService.GetAllPiratesWithData();


            return View(pirates);
        }

        public IActionResult RandomSaying()
        {
            return View();
        }

        public IActionResult AddForm(PirateViewModel v = null)

        {

            if (v == null)
            {
                v = new PirateViewModel();
                v.FormMode = FormMode.AddNumberofQuotesAndBattles;
            }
            else
            {
                v.Pirate = new Pirate();


                for (int i = 0; i < v.NumberOfQuotes; i++)
                {
                    v.Pirate.Sayings.Add(new Saying() { Text = "", Pirate = v.Pirate });
                }


                for (int i = 0; i < v.NumberOfBattles; i++)
                {
                    Random r = new Random();
                    int numberDays1 = -r.Next(1, 20000);
                    int numberDays2 = numberDays1 - 2;

                    v.Duels.Add(new Duel()
                    {
                        Name = "",
                        StartDate = DateTime.Now.AddDays(numberDays2),
                        EndDate = DateTime.Now.AddDays(numberDays1)
                    });
                }
            }


            return View(v);
        }

        [HttpPost]
        public IActionResult Add(PirateViewModel pirateViewModel)
        {
            var pirate = pirateViewModel.Pirate;

            foreach (var item in pirateViewModel.Duels)
            {
                PirateDuel pirateDuel = new PirateDuel();

                pirateDuel.Duel = item;
                pirateDuel.Pirate = pirate;
                pirate.PirateDuels.Add(pirateDuel);
            }

            _pirateService.AddPirate(pirate);


            return RedirectToAction("Index");
        }
    }
}