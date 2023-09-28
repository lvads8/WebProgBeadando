using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProgBeadando.Data;

namespace WebProgBeadando.Controllers;

public class AchievementController : Controller
{
    private readonly ApplicationDbContext _db;

    public AchievementController(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        var data = await _db.Achievements.ToListAsync();

        return View(data);
    }

    public async Task<IActionResult> Details(Guid id)
    {
        var achievement = await _db.Achievements.FindAsync(id);
        if (achievement is null)
        {
            return NotFound();
        }

        return View(achievement);
    }
}