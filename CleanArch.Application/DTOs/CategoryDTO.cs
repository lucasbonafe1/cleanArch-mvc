using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CleanArch.Application.DTOs;

public class CategoryDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The Name is required")]
    [StringLength(100, ErrorMessage = "The Name must be between 3 and 100 characters", MinimumLength = 3)]
    [DisplayName("Category Name")]
    public string Name { get; set; } = string.Empty;
}
