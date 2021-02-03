using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabbTsb.Controllers
{
    public class CitiesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
