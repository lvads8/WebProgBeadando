using System.ComponentModel.DataAnnotations;

namespace WebProgBeadando.Dtos;

public class CreateFileDto
{
    [Required]
    [MaxLength(30)]
    public required string Name { get; set; }
    public string? Description { get; set; }
    [Required]
    public required IFormFile File { get; set; }
}