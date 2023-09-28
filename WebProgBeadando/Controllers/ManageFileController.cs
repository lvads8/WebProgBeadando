using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProgBeadando.Data;
using WebProgBeadando.Dtos;
using WebProgBeadando.Models;

namespace WebProgBeadando.Controllers;

[Authorize(Roles = "Admin")]
public class ManageFileController : Controller
{

    private readonly ApplicationDbContext _db;
    private readonly IHostEnvironment _hostEnvironment;

    public ManageFileController(ApplicationDbContext db, IHostEnvironment hostEnvironment)
    {
        _db = db;
        _hostEnvironment = hostEnvironment;
    }

    public async Task<IActionResult> Index()
    {
        var achievements = await _db.Files.ToListAsync();

        return View(achievements);
    }

    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateFileDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }

        string randomFileName = GetUniqueFileName(dto.File);
        string wwwroot = _hostEnvironment.ContentRootPath;
        string filePath = Path.Combine(wwwroot, "wwwroot", "files", randomFileName);
        Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

        await dto.File.CopyToAsync(new FileStream(filePath, FileMode.CreateNew));

        var model = new FileModel
        {
            Name = dto.Name,
            Description = dto.Description,
            OriginalName = dto.File.FileName,
            UploadedAt = DateTime.Now,
            // Authorization is required, so we always have a user.
            UploadedBy = User!.Identity!.Name!,
            Path = $"/files/{randomFileName}"
        };

        _db.Files.Add(model);
        await _db.SaveChangesAsync();

        return RedirectToAction(nameof(Index));

        string GetUniqueFileName(IFormFile formFile)
        {
            string extension = Path.GetExtension(formFile.FileName) ?? "";
            return $"{Guid.NewGuid().ToString()[..8]}{extension}";
        }
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var data = await _db.Files.FindAsync(id);
        if (data is null)
        {
            return NotFound();
        }

        return View(data);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Description")] FileModel model)
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
            _db.Files.Update(model);
            await _db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            bool exists = await _db.Files.FindAsync(id) is not null;
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
        var data = await _db.Files.FindAsync(id);
        if (data is null)
        {
            return NotFound();
        }

        return View(data);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Destroy(Guid id)
    {
        var data = await _db.Files.FindAsync(id);
        if (data is null)
        {
            return NotFound();
        }

        _db.Files.Remove(data);
        await _db.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}