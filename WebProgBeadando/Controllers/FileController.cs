using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProgBeadando.Data;

namespace WebProgBeadando.Controllers;

[Authorize]
public class FileController : Controller
{
    private readonly ApplicationDbContext _db;

    public FileController(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        var data = await _db.Files.ToListAsync();

        return View(data);
    }

    public async Task<IActionResult> Details(Guid id)
    {
        var data = await _db.Files.FindAsync(id);
        if (data is null)
        {
            return NotFound();
        }

        return View(data);
    }
}