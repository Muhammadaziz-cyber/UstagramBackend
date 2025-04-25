using Ustagram.Domain.DTOs;
using Ustagram.Domain.Model;

namespace Ustagram.Application.Abstractions;

public interface IPostService
{
    public Task<string> CreatePost(PostDTO postDto);
    public Task<Post> GetPostById(Guid postId);
    public Task<string> UpdatePost(Guid postId, PostDTO postDto);
    public Task<string> DeletePost(Guid postId);
    public Task<List<Post>> GetAllPosts();
    public Task<List<Post>> GetPostsLastFive();
    public Task<List<Post>> GetPostsTopFive();
    public Task<List<Post>> GetPostsIshCategory();
    public Task<List<Post>> GetPostsSotuvCategory();
    public Task<List<Post>> GetPostsReklamaCategory();

}