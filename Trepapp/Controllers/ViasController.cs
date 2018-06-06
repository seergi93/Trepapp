using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trepapp.Data;
using Trepapp.Models;

namespace Trepapp.Controllers
{
    public class ViasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ViaModels viaModels;

        public ViasController(ApplicationDbContext context)
        {
            _context = context;
            viaModels = new ViaModels(context);
        }

        // GET: Vias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Via.ToListAsync());
        }
        //public List<object[]> filtrarVia(int numPagina, string valor, string order)
        //{
        //    return viaModels.filtrarVia(numPagina, valor, order);
        //}

        public List<Sector> getSectores()
        {
            return viaModels.getSectores();
        }


        // GET: Vias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var via = await _context.Via
                .SingleOrDefaultAsync(m => m.ViaId == id);
            if (via == null)
            {
                return NotFound();
            }

            return View(via);
        }

        // GET: Vias/Create
        public IActionResult Create()
        {
            return View();
        }
        
        public List<IdentityError> agregarVia(int id, string nombre, string descripcion, string grado, int sector, string funcion)
        {
            return viaModels.agregarVia(id, nombre, descripcion, grado, sector, funcion);
        }

        // POST: Vias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ViaId,Nombre,Descripcion,Grado,SectorId")] Via via)
        {
            if (ModelState.IsValid)
            {
                _context.Add(via);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(via);
        }

        // GET: Vias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var via = await _context.Via.SingleOrDefaultAsync(m => m.ViaId == id);
            if (via == null)
            {
                return NotFound();
            }
            return View(via);
        }

        // POST: Vias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ViaId,Nombre,Descripcion,Grado,SectorId")] Via via)
        {
            if (id != via.ViaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(via);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ViaExists(via.ViaId))
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
            return View(via);
        }

        // GET: Vias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var via = await _context.Via
                .SingleOrDefaultAsync(m => m.ViaId == id);
            if (via == null)
            {
                return NotFound();
            }

            return View(via);
        }

        // POST: Vias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var via = await _context.Via.SingleOrDefaultAsync(m => m.ViaId == id);
            _context.Via.Remove(via);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ViaExists(int id)
        {
            return _context.Via.Any(e => e.ViaId == id);
        }
    }
}
