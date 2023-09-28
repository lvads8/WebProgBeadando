using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebProgBeadando.Models;

// Model only because of collision with System.IO.File
[PrimaryKey(nameof(Id))]
public class FileModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    [Required]
    [MaxLength(50)]
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required string Path { get; set; }
    public required string OriginalName { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime UploadedAt { get; set; } = DateTime.Now;
    [Required]
    [MaxLength(255)]
    public required string UploadedBy { get; set; }
}