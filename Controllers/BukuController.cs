using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PerpusWebProject.Data;
using PerpusWebProject.Models;

namespace PerpusWebProject.Controllers
{
    public class BukuController : Controller
    {
        private readonly AppDbContext _context;

        public BukuController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Buku
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bukus.ToListAsync());
        }

        // GET: Buku/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buku = await _context.Bukus
                .FirstOrDefaultAsync(m => m.IdBuku == id);
            if (buku == null)
            {
                return NotFound();
            }

            return View(buku);
        }

        // GET: Buku/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Buku/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBuku,Judul,Penulis,Penerbit,TahunTerbit,Kategori,Stok")] Buku buku)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buku);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(buku);
        }

        // GET: Buku/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buku = await _context.Bukus.FindAsync(id);
            if (buku == null)
            {
                return NotFound();
            }
            return View(buku);
        }

        // POST: Buku/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBuku,Judul,Penulis,Penerbit,TahunTerbit,Kategori,Stok")] Buku buku)
        {
            if (id != buku.IdBuku)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buku);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BukuExists(buku.IdBuku))
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
            return View(buku);
        }

        // GET: Buku/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buku = await _context.Bukus
                .FirstOrDefaultAsync(m => m.IdBuku == id);
            if (buku == null)
            {
                return NotFound();
            }

            return View(buku);
        }

        // POST: Buku/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var buku = await _context.Bukus.FindAsync(id);
            if (buku != null)
            {
                _context.Bukus.Remove(buku);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BukuExists(int id)
        {
            return _context.Bukus.Any(e => e.IdBuku == id);
        }
    }
}
