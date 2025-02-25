namespace backend.Dtos.Comment;

public class UpdateCommentDto
{
    public string Content { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public int StockId { get; set; }
    
}