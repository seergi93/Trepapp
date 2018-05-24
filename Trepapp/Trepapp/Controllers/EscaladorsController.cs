using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trepapp.Models;

namespace Trepapp.Controllers
{
    public class EscaladorsController : Controller
    {
        private readonly TrepappContext _context;

        public EscaladorsController(TrepappContext context)
        {
            _context = context;
        }

        // GET: Escaladors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Escalador.ToListAsync());
        }

        // GET: Escaladors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escalador = await _context.Escalador
                .SingleOrDefaultAsync(m => m.EscaladorId == id);
            if (escalador == null)
            {
                return NotFound();
            }

            return View(escalador);
        }

        // GET: Escaladors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Escaladors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EscaladorId,NombreApellido,Password,Nick,DataNeixament,Federat")] Escalador escalador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(escalador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(escalador);
        }

        // GET: Escaladors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escalador = await _context.Escalador.SingleOrDefaultAsync(m => m.EscaladorId == id);
            if (escalador == null)
            {
                return NotFound();
            }
            return View(escalador);
        }

        // POST: Escaladors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EscaladorId,NombreApellido,Password,Nick,DataNeixament,Federat")] Escalador escalador)
        {
            if (id != escalador.EscaladorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(escalador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EscaladorExists(escalador.EscaladorId))
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
            return View(escalador);
        }

        // GET: Escaladors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escalador = await _context.Escalador
                .SingleOrDefaultAsync(m => m.EscaladorId == id);
            if (escalador == null)
            {
                return NotFound();
            }

            return View(escalador);
        }

        // POST: Escaladors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var escalador = await _context.Escalador.SingleOrDefaultAsync(m => m.EscaladorId == id);
            _context.Escalador.Remove(escalador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EscaladorExists(int id)
        {
            return _context.Escalador.Any(e => e.EscaladorId == id);
        }
    }
}
