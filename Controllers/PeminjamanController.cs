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
    public class PeminjamanController : Controller
    {
        private readonly AppDbContext _context;

        public PeminjamanController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Peminjaman
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Peminjamans.Include(p => p.Buku).Include(p => p.User);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Peminjaman/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peminjaman = await _context.Peminjamans
                .Include(p => p.Buku)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.IdPeminjaman == id);
            if (peminjaman == null)
            {
                return NotFound();
            }

            return View(peminjaman);
        }

        // GET: Peminjaman/Create
        public IActionResult Create()
        {
            ViewData["IdBuku"] = new SelectList(_context.Bukus, "IdBuku", "Judul");
            ViewData["IdUser"] = new SelectList(_context.Users, "IdUser", "Nama");
            return View();
        }

        // POST: Peminjaman/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPeminjaman,IdBuku,IdUser,TanggalPinjam,TanggalKembali,Status")] Peminjaman peminjaman)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peminjaman);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBuku"] = new SelectList(_context.Bukus, "IdBuku", "Judul", peminjaman.IdBuku);
            ViewData["IdUser"] = new SelectList(_context.Users, "IdUser", "Nama", peminjaman.IdUser);
            return View(peminjaman);
        }

        // GET: Peminjaman/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peminjaman = await _context.Peminjamans.FindAsync(id);
            if (peminjaman == null)
            {
                return NotFound();
            }
            ViewData["IdBuku"] = new SelectList(_context.Bukus, "IdBuku", "Judul", peminjaman.IdBuku);
            ViewData["IdUser"] = new SelectList(_context.Users, "IdUser", "Nama", peminjaman.IdUser);
            return View(peminjaman);
        }

        // POST: Peminjaman/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPeminjaman,IdBuku,IdUser,TanggalPinjam,TanggalKembali,Status")] Peminjaman peminjaman)
        {
            if (id != peminjaman.IdPeminjaman)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peminjaman);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeminjamanExists(peminjaman.IdPeminjaman))
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
            ViewData["IdBuku"] = new SelectList(_context.Bukus, "IdBuku", "Judul", peminjaman.IdBuku);
            ViewData["IdUser"] = new SelectList(_context.Users, "IdUser", "Nama", peminjaman.IdUser);
            return View(peminjaman);
        }

        // GET: Peminjaman/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peminjaman = await _context.Peminjamans
                .Include(p => p.Buku)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.IdPeminjaman == id);
            if (peminjaman == null)
            {
                return NotFound();
            }

            return View(peminjaman);
        }

        // POST: Peminjaman/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var peminjaman = await _context.Peminjamans.FindAsync(id);
            if (peminjaman != null)
            {
                _context.Peminjamans.Remove(peminjaman);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Kembalikan(int id)
        {
            var peminjaman = await _context.Peminjamans
                .Include(p => p.Buku)
                .FirstOrDefaultAsync(p => p.IdPeminjaman == id);

            if (peminjaman == null)
            {
                return NotFound();
            }


            peminjaman.Status = "Dikembalikan";
            peminjaman.TanggalKembali = DateTime.Now;


            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }
        private bool PeminjamanExists(int id)
        {
            return _context.Peminjamans.Any(e => e.IdPeminjaman == id);
        }
    }
}
