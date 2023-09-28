using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebProgBeadando.Models;

// Model only because of collision with System.IO.File
[PrimaryKey(nameof(Id))]
public class FileModel
{
    public Guid Id { get; set; }
    [MaxLength(50)]
    public required string Name { get; set; }
    [MaxLength(50)]
    public required string Description { get; set; }
    public required string Path { get; set; }
    [DataType(DataType.Date)]
    public DateTime UploadedAt { get; set; } = DateTime.Now;
    public required string UploadedBy { get; set; }
}