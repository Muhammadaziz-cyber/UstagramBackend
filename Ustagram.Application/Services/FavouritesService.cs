using Microsoft.EntityFrameworkCore;
using Ustagram.Application.Abstractions;
using Ustagram.Domain.DTOs;
using Ustagram.Domain.Model;
using Ustagram.Infrastructure.Persistance;

namespace Ustagram.Application.Services;

public class FavouritesService : IFavouritesService
{
    private readonly ApplicationDbContext _db;

    public FavouritesService(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task<string> CreateFavourites(FaouriteDTO FavouritesDto)
    {
        var newFavourites = new Favourites
        {
            PostId = FavouritesDto.PostId,
            UserId = FavouritesDto.UserId,
        };
        _db.Favourites.Add(newFavourites);
        await _db.SaveChangesAsync();
        return "Favourites created";
    }

    public async Task<Favourites> GetFavouritesById(Guid FavouritesId)
    {
        var favorit = await _db.Favourites.FirstOrDefaultAsync(f=> f.Id == FavouritesId);
        return favorit;
    }

    public async Task<string> UpdateFavourites(Guid FavouritesId, FaouriteDTO FavouritesDto)
    {
        var favorit = await _db.Favourites.FirstOrDefaultAsync(f=> f.Id == FavouritesId);
        favorit.PostId = FavouritesDto.PostId;
        favorit.UserId = FavouritesDto.UserId;
        await _db.SaveChangesAsync();
        return "Favourites updated";
    }

    public async Task<string> DeleteFavourites(Guid FavouritesId)
    {
        var favorit = await _db.Favourites.FirstOrDefaultAsync(f=> f.Id == FavouritesId);
        _db.Favourites.Remove(favorit);
        await _db.SaveChangesAsync();
        return "Favourites deleted";
    }

    public async Task<List<Favourites>> GetAllFavouritess()
    {
        var favourites = await _db.Favourites.ToListAsync();
        return favourites;
    }
}