using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerpusWebProject.Data;
using PerpusWebProject.Models;

namespace PerpusWebProject.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }


    public async Task<IActionResult> Index()
    {
        ViewBag.TotalBuku = await _context.Bukus.CountAsync();

        ViewBag.TotalUser = await _context.Users.CountAsync();

        ViewBag.TotalPeminjaman = await _context.Peminjamans.CountAsync();

        return View();
    }


    public IActionResult Privacy()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }
}