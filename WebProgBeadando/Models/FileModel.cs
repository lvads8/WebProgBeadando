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
    [Display(Name = "Original name")]
    public required string OriginalName { get; set; }
    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Uploaded at")]
    public DateTimeOffset UploadedAt { get; set; } = DateTimeOffset.Now;
    [Required]
    [MaxLength(255)]
    [Display(Name = "Uploaded by")]
    public required string UploadedBy { get; set; }
}