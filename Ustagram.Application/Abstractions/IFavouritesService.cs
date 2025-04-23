using Ustagram.Domain.DTOs;
using Ustagram.Domain.Model;

namespace Ustagram.Application.Abstractions;

public interface IFavouritesService
{
    public Task<string> CreateFavourites(FaouriteDTO FavouritesDto);
    public Task<Favourites> GetFavouritesById(Guid FavouritesId);
    public Task<string> UpdateFavourites(Guid FavouritesId, FaouriteDTO FavouritesDto);
    public Task<string> DeleteFavourites(Guid FavouritesId);
    public Task<List<Favourites>> GetAllFavouritess();
}