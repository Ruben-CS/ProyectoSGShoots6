using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoSGShoots6.Controllers
{
    public class PaqueteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}