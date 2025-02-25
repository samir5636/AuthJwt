using backend.Dtos.Comment;
using backend.Models;

namespace backend.Interfaces;

public interface ICommentRepository
{
    Task<List<Comments>> GetAllAsync();
    Task<Comments?> GetByIdAsync(int id);
    Task<Comments> CreateAsync(Comments comments);
    Task<Comments?> UpdateAsync(int id, Comments comment);
    Task<Comments?> DeleteAsync(int id);
}