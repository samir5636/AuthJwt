namespace backend.Dtos.Comment;

public class CreateCommentRequestDto
{
    public string Content { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
}