using Microsoft.EntityFrameworkCore;
using Ustagram.Application.Abstractions;
using Ustagram.Domain.DTOs;
using Ustagram.Domain.Model;
using Ustagram.Infrastructure.Persistance;

namespace Ustagram.Application.Services;

public class CommentService : ICommentService
{
    private readonly ApplicationDbContext _db;

    public CommentService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<string> CreateComment(CommentDTO CommentDto)
    {
        var comment = new Comment
        {
            Content = CommentDto.Content,
            Date = CommentDto.Date,
            UserId = CommentDto.UserId,
            PostId = CommentDto.PostId
        };
        
        var post = await _db.Posts.Include(p => p.Comments).FirstOrDefaultAsync(p => p.Id == CommentDto.PostId);
        if (post == null)
            return "Post not found";
        await _db.Comments.AddAsync(comment);
        await _db.SaveChangesAsync();
        return "Comment created";
    }

    public async Task<Comment> GetCommentById(Guid CommentId)
    {
        var comment = await _db.Comments.FirstOrDefaultAsync(c => c.Id == CommentId);
        return comment;
    }

    public async Task<string> UpdateComment(Guid CommentId, CommentDTO CommentDto)
    {
        var comment = await _db.Comments.FirstOrDefaultAsync(c => c.Id == CommentId);
        comment.Content = CommentDto.Content;
        comment.Date = CommentDto.Date;
        comment.UserId = CommentDto.UserId;
        comment.PostId = CommentDto.PostId;
        await _db.SaveChangesAsync();
        return "Comment updated";
    }

    public async Task<string> DeleteComment(Guid CommentId)
    {
        var comment = await _db.Comments.FirstOrDefaultAsync(c => c.Id == CommentId);
        _db.Comments.Remove(comment);
        await _db.SaveChangesAsync();
        return "Comment deleted";
    }

    public async Task<List<Comment>> GetAllComments()
    {
        var comments = await _db.Comments.ToListAsync();
        return comments;
    }
}