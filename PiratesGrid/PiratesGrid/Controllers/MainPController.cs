using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PiratesGrid.Services;

namespace PiratesGrid.Controllers
{
    //[Route("")]
    public class MainPController : Controller
    {
        private IPirateService _pirateService;

        public MainPController(IPirateService pirateService)
        {
            _pirateService = pirateService;
        }

        //[Route("")]
        public IActionResult Index()
        {
            ViewBag.Title = "Welcome to Pirate Site my Friend";
            return View();
        }
    }
}