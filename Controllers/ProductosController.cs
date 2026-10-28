using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using inventariosmvc.Models;
using Microsoft.EntityFrameworkCore;

namespace inventariosmvc.Controllers;

public class ProductosController : Controller
{
    private readonly InventarioContext _context;

    public ProductosController(InventarioContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var productos = await _context.Productos
            .AsNoTracking()
            .ToListAsync();

        return View(productos);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}