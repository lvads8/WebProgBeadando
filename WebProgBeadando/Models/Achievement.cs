using Microsoft.EntityFrameworkCore;

namespace WebProgBeadando.Models;

[PrimaryKey(nameof(Id))]
public class Achievement
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required DateTime Date { get; set; }
    public string Description { get; set; } = "";
}