using Microsoft.AspNetCore.Mvc;
using Ustagram.Application.Abstractions;
using Ustagram.Domain.DTOs;

namespace Ustagram.API.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class FavouritesController : ControllerBase
{
    private readonly IFavouritesService _service;

    public FavouritesController(IFavouritesService service)
    {
        _service = service;
    }


    [HttpPost]
    public async Task<ActionResult<string>> CreateFavourite([FromForm] FaouriteDTO favouriteDto)
    {
        var favourite = await _service.CreateFavourites(favouriteDto);
        if (favourite == null)
            return "Favourite could not be created";
        return favourite;
    }


    [HttpGet]
    public async Task<ActionResult<Domain.Model.Favourites>> GetFavouriteById( Guid id)
    {
        var favourite = await _service.GetFavouritesById(id);
        if (favourite == null)
            return BadRequest("Favourite could not be found");
        return Ok(favourite);
    }

    [HttpPut]
    public async Task<ActionResult<string>> UpdateFavourite(Guid id,[FromForm] FaouriteDTO favouriteDto)
    {
        var favarit  = await _service.UpdateFavourites(id, favouriteDto);
        if (favarit == null)
            return BadRequest("Favourite could not be updated");
        return Ok(favarit);
    }

    [HttpDelete]
    public async Task<ActionResult<string>> DeleteFavourite([FromForm] Guid id)
    {
        var favourite = await _service.DeleteFavourites(id);
        if (favourite == null)
            return BadRequest("Favourite could not be deleted");
        return Ok(favourite);
    }


    [HttpGet]
    public async Task<List<Domain.Model.Favourites>> GetFavourites()
    {
        return await _service.GetAllFavouritess();
    }
}