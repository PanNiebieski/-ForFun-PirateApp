using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PiratesGrid.Services;

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
            return View();
        }
    }
}