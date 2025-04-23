using Microsoft.AspNetCore.Mvc;
using Ustagram.Application.Abstractions;
using Ustagram.Domain.DTOs;
using Ustagram.Domain.Model;

namespace Ustagram.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]

public class PostController : ControllerBase
{
    private readonly IPostService _service;

    public PostController(IPostService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreatePost([FromForm] PostDTO postDto)
    {
        var result = await _service.CreatePost(postDto);
        if (result == null)
            return BadRequest("Post not created");
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<ActionResult<Post>> GetPostById( Guid postId)
    {
        var result = await _service.GetPostById(postId);
        if (result == null)
            return BadRequest("Post not found");
        return Ok(result);
    }


    [HttpPut]
    public async Task<ActionResult<string>> UpdatePost( Guid postId,[FromForm] PostDTO postDto)
    {
        var result = await _service.UpdatePost(postId, postDto);
        if (result == null)
            return BadRequest("Post not updated");
        return Ok(result);
    }

    [HttpDelete]
    public async Task<ActionResult<string>> DeletePost([FromForm] Guid postId)
    {
        var result = await _service.DeletePost(postId);
        if (result == null)
            return BadRequest("Post not deleted");
        return Ok(result);
    }


    [HttpGet]
    public async Task<ActionResult<Post>> GetAllPosts()
    {
        var result = await _service.GetAllPosts();
        return Ok(result);
    }
}