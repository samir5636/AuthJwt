using backend.Data;
using backend.Dtos.Comment;
using backend.Interfaces;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository;

public class CommentRepository : ICommentRepository
{
    private readonly ApplicationDbContext _context;
    public CommentRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    
    public async Task<List<Comments>> GetAllAsync()
    {
        return await _context.Comments.ToListAsync();
    }

    public async Task<Comments?> GetByIdAsync(int id)
    {
        var commentModel = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);

        if (commentModel is null)
        {
            return null;
        }
        await _context.SaveChangesAsync();
        
        return commentModel;
        
    }
    


    public async Task<Comments> CreateAsync(Comments commentModel)
    {
        await _context.Comments.AddAsync(commentModel);
        await _context.SaveChangesAsync();
        return commentModel;
    }

    public async Task<Comments?> UpdateAsync(int id, Comments comment)
    {
        var existingComment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
        if (existingComment is null)
        {
            return null;
        }
        existingComment.Content = comment.Content;
        existingComment.Title = comment.Title;
        
        await _context.SaveChangesAsync();
        return existingComment;
    }


    public async Task<Comments?> DeleteAsync(int id)
    {
        var commentModel = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);

        if (commentModel is null)
        {
            return null;
        }
        _context.Comments.Remove(commentModel);
        await _context.SaveChangesAsync();
        return commentModel;
    }
}