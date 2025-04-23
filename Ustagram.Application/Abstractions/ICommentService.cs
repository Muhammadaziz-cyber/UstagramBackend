using Ustagram.Domain.DTOs;
using Ustagram.Domain.Model;

namespace Ustagram.Application.Abstractions;

public interface ICommentService
{
    public Task<string> CreateComment(CommentDTO CommentDto);
    public Task<Comment> GetCommentById(Guid CommentId);
    public Task<string> UpdateComment(Guid CommentId, CommentDTO CommentDto);
    public Task<string> DeleteComment(Guid CommentId);
    public Task<List<Comment>> GetAllComments();
}