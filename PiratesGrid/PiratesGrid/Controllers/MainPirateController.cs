using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PiratesGrid.Services;

namespace PiratesGrid.Controllers
{
    [Route("Home")]
    public class MainPirateController : Controller
    {
        private IPirateService _pirateService;

        public MainPirateController(IPirateService pirateService)
        {
            _pirateService = pirateService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}