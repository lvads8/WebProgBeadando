using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProgBeadando.Data;
using WebProgBeadando.Models;

namespace WebProgBeadando.Controllers;

[Authorize(Roles = "Admin")]
public class ManageAchievementController : Controller
{

    private readonly ApplicationDbContext _db;

    public ManageAchievementController(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        var achievements = await _db.Achievements.ToListAsync();

        return View(achievements);
    }

    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name,Date,Description")] Achievement model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        _db.Achievements.Add(model);
        await _db.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Edit(Guid id)
    {
        var data = await _db.Achievements.FindAsync(id);
        if (data is null)
        {
            return NotFound();
        }

        return View(data);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Date,Description")] Achievement model)
    {
        if (id != model.Id)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            _db.Achievements.Update(model);
            await _db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            bool exists = await _db.Achievements.FindAsync(id) is not null;
            if (!exists)
            {
                return NotFound();
            }

            throw;
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        var data = await _db.Achievements.FindAsync(id);
        if (data is null)
        {
            return NotFound();
        }

        return View(data);
    }

    [HttpPost]
    public async Task<IActionResult> Destroy(Guid id)
    {
        var data = await _db.Achievements.FindAsync(id);
        if (data is null)
        {
            return NotFound();
        }

        _db.Achievements.Remove(data);
        await _db.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}