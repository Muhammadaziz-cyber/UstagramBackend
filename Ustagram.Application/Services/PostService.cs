using Microsoft.EntityFrameworkCore;
using Ustagram.Application.Abstractions;
using Ustagram.Domain.DTOs;
using Ustagram.Domain.Model;
using Ustagram.Infrastructure.Persistance;

namespace Ustagram.Application.Services;

public class PostService : IPostService
{
    private readonly ApplicationDbContext _db;

    public PostService(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task<string> CreatePost(PostDTO postDto)
    {
        var newPost = new Post
        {
            UserId = postDto.UserId,
            PostType = postDto.PostType,
            Text = postDto.Text,
            Description = postDto.Description,
            Price = postDto.Price,
            PhotoPath = postDto.PhotoPath,
            Date = postDto.Date,
            Likes = postDto.Likes,
            Dislikes = postDto.Dislikes,
        };
        await _db.Posts.AddAsync(newPost);
        await _db.SaveChangesAsync();
        return "Post created";
    }

    public async Task<Post> GetPostById(Guid postId)
    {
        var post = await _db.Posts.Include(p => p.Comments).FirstOrDefaultAsync(p => p.Id == postId);
        return post;
    }

    public async Task<string> UpdatePost(Guid postId, PostDTO postDto)
    {
        var post = await _db.Posts.FirstOrDefaultAsync(p => p.Id == postId);
        post.UserId = postDto.UserId;
        post.PostType = postDto.PostType;
        post.Text = postDto.Text;
        post.Description = postDto.Description;
        post.Price = postDto.Price;
        post.PhotoPath = postDto.PhotoPath;
        post.Date = postDto.Date;
        post.Likes = postDto.Likes;
        post.Dislikes = postDto.Dislikes;
        await _db.SaveChangesAsync();
        return "Post updated";
    }

    public async Task<string> DeletePost(Guid postId)
    {
        var post = await _db.Posts.FirstOrDefaultAsync(p => p.Id == postId);
        _db.Posts.Remove(post);
        await _db.SaveChangesAsync();
        return "Post deleted";
    }

    public async Task<List<Post>> GetAllPosts()
    {
        var posts = await _db.Posts.Include(p => p.Comments).ToListAsync();
        return posts;
    }
}