using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp_DnD.Data;
using WebApp_DnD.Models;

namespace WebApp_DnD.Controllers
{
    public class RollController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RollController(ApplicationDbContext context) {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Die> dice = new List<Die>();

            dice = _context.Dice.ToList();

            ViewBag.ListOfDice = dice;
            return View();
        }

        [HttpPost]
        public IActionResult Index(Die die) {

            ViewBag.SelectedValue = die.NumSides;

            Random rnd = new Random();
            ViewBag.rolledValue = rnd.Next(1, die.NumSides + 1);

            List<Die> dice = new List<Die>();
            dice = _context.Dice.ToList();
            ViewBag.ListOfDice = dice;


            return View();
        }
    }
}