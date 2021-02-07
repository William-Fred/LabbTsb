using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabbTsb.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            try
            {
                return View();
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return View();
            }
        }

      public IActionResult Contact()
        {
            return View();
        }

        public IActionResult ErrorMessage()
        {
            return View();
        }
    }
}
