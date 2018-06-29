using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp_DnD.Data;
using WebApp_DnD.Models;

namespace WebApp_DnD.Controllers
{
    public class CharactersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CharactersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Characters
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Characters.Include(c => c.AppUser).Include(c => c.CharAlign).Include(c => c.CharClass).Include(c => c.CharRace);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Characters/Details/5
        [Authorize]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var character = await _context.Characters
                .Include(c => c.AppUser)
                .Include(c => c.CharAlign)
                .Include(c => c.CharClass)
                .Include(c => c.CharRace)
                .SingleOrDefaultAsync(m => m.Name == id);

            if (character == null) {
                return NotFound();
            }

            var Equipment = _context.CharacterEquipment.Where(r => r.Name == id).ToList();
            ViewBag.Equipment = Equipment;
            var prof = _context.Proficiencies.Where(r => r.Name == id).ToList();
            ViewBag.Proficiency = prof;



            ViewData["User"] = new SelectList(_context.Users, "Id", "Id", character.User);
            ViewData["Alignment"] = new SelectList(_context.Alignments, "AlignmentCode", "AlignmentCode", character.Alignment);
            ViewData["Class"] = new SelectList(_context.CharacterClasses, "Name", "Name", character.Class);
            ViewData["Race"] = new SelectList(_context.CharacterRaces, "Name", "Name", character.Race);
            return View(character);
        }






        // GET: Characters/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["User"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["Alignment"] = new SelectList(_context.Alignments, "AlignmentCode", "AlignmentCode");
            ViewData["Class"] = new SelectList(_context.CharacterClasses, "Name", "Name");
            ViewData["Race"] = new SelectList(_context.CharacterRaces, "Name", "Name");
            return View();
        }

        // POST: Characters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("User,Name,Class,Race,Alignment")] Character character)
        {
            if (ModelState.IsValid)
            {
                _context.Add(character);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["User"] = new SelectList(_context.Users, "Id", "Id", character.User);
            ViewData["Alignment"] = new SelectList(_context.Alignments, "AlignmentCode", "AlignmentCode", character.Alignment);
            ViewData["Class"] = new SelectList(_context.CharacterClasses, "Name", "Name", character.Class);
            ViewData["Race"] = new SelectList(_context.CharacterRaces, "Name", "Name", character.Race);
            return View(character);
        }

        // GET: Characters/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Characters.SingleOrDefaultAsync(m => m.Name == id);
            if (character == null)
            {
                return NotFound();
            }
            ViewData["User"] = new SelectList(_context.Users, "Id", "Id", character.User);
            ViewData["Alignment"] = new SelectList(_context.Alignments, "AlignmentCode", "AlignmentCode", character.Alignment);
            ViewData["Class"] = new SelectList(_context.CharacterClasses, "Name", "Name", character.Class);
            ViewData["Race"] = new SelectList(_context.CharacterRaces, "Name", "Name", character.Race);
            return View(character);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(string id, [Bind("User,Name,Class,Race,Alignment")] Character character)
        {
            if (id != character.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(character);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacterExists(character.Name))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["User"] = new SelectList(_context.Users, "Id", "Id", character.User);
            ViewData["Alignment"] = new SelectList(_context.Alignments, "AlignmentCode", "AlignmentCode", character.Alignment);
            ViewData["Class"] = new SelectList(_context.CharacterClasses, "Name", "Name", character.Class);
            ViewData["Race"] = new SelectList(_context.CharacterRaces, "Name", "Name", character.Race);
            return View(character);
        }

        // GET: Characters/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Characters
                .Include(c => c.AppUser)
                .Include(c => c.CharAlign)
                .Include(c => c.CharClass)
                .Include(c => c.CharRace)
                .SingleOrDefaultAsync(m => m.Name == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var character = await _context.Characters.SingleOrDefaultAsync(m => m.Name == id);
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharacterExists(string id)
        {
            return _context.Characters.Any(e => e.Name == id);
        }
    }
}
