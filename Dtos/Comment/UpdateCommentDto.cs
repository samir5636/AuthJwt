using System.ComponentModel.DataAnnotations;

namespace backend.Dtos.Comment;

public class UpdateCommentDto
{
    
    [Required]
    [MinLength(5, ErrorMessage = "Content must be at least 3 characters long.")]
    [MaxLength(280, ErrorMessage = "Content must not be Longer than 280 characters.")]
    public string Content { get; set; } = string.Empty;
    
    [Required]
    [MinLength(5, ErrorMessage = "Title must be at least 3 characters long.")]
    [MaxLength(280, ErrorMessage = "Title must not be Longer than 280 characters.")]
    public string Title { get; set; } = string.Empty;
    public int StockId { get; set; }
    
}