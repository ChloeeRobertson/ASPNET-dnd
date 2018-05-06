using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApp_DnD.Controllers
{
    public class RollController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}