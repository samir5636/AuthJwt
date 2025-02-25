using backend.Dtos.Comment;
using backend.Models;

namespace backend.Mappers;

public static class CommentMappers
{

    public static CommentDto ToCommentDto(this Comments comment)
    {
        return new CommentDto
        {
            Id = comment.Id,
            Content = comment.Content,
            Title = comment.Title,
            CreatOn = comment.CreatOn,
            StockId = comment.StockId,
        };
    }

    public static Comments ToCommentsFromCreatDto(this CreateCommentRequestDto commentDto, int stockId)
    {
        return new Comments
        {
            Content = commentDto.Content,
            Title = commentDto.Title,
            StockId = stockId,
        };
    }
    
    public static Comments ToCommentsFromUpdateDto(this UpdateCommentDto commentDto)
    {
        return new Comments
        {
            Content = commentDto.Content,
            Title = commentDto.Title,
        };
    }
    
}