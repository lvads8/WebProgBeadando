using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebProgBeadando.Models;

[PrimaryKey(nameof(Id))]
public class Achievement
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    [DataType(DataType.Date)]
    public required DateTime Date { get; set; }
    public string Description { get; set; } = "";
}