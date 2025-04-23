using Microsoft.AspNetCore.Mvc;
using Ustagram.Application.Abstractions;
using Ustagram.Domain.DTOs;

namespace Ustagram.API.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateComment([FromForm] CommentDTO commentDTO)
    {
        var comment = await _commentService.CreateComment(commentDTO);
        if (comment == null)
            return BadRequest("Comment could not be created");
        return Ok(comment);
    }

    [HttpGet]
    public async Task<ActionResult<Domain.Model.Comment>> GetCommentById(Guid id)
    {
        var comment = await _commentService.GetCommentById(id);
        if (comment == null)
            return BadRequest("Comment could not be found");
        return Ok(comment);
    }

    [HttpPut]
    public async Task<ActionResult<string>> UpdateComment(Guid id,[FromForm] CommentDTO commentDTO)
    {
        var comment = await _commentService.UpdateComment(id, commentDTO);
        if (comment == null)
            return BadRequest("Comment could not be updated");
        return Ok(comment);
    }


    [HttpDelete]
    public async Task<ActionResult<string>> DeleteComment([FromForm] Guid id)
    {
        var comment = await _commentService.DeleteComment(id);
        if (comment == null)
            return BadRequest("Comment could not be deleted");
        return Ok(comment);
    }

    [HttpGet]
    public async Task<ActionResult<List<Domain.Model.Comment>>> GetAllComments()
    {
        var comments = await _commentService.GetAllComments();
        if (comments == null)
            return BadRequest("Comment could not be found");
        return Ok(comments);
    }
}