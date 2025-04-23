using Microsoft.EntityFrameworkCore;
using Ustagram.Application.Abstractions;
using Ustagram.Domain.DTOs;
using Ustagram.Domain.Model;
using Ustagram.Infrastructure.Persistance;

namespace Ustagram.Application.Services;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _db;

    public UserService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<string> CreateUser(UserDTO userDto)
    {
        var newUser = new User
        {
            FullName = userDto.FullName,
            Username = userDto.Username,
            Phone = userDto.Phone,
            Location = userDto.Location,
            PhotoPath = userDto.PhotoPath,
            Dob = userDto.Dob,
            Status = userDto.Status,
            MasterType = userDto.MasterType,
            Bio = userDto.Bio,
            Experience = userDto.Experience,
            TelegramUrl = userDto.TelegramUrl,
            InstagramUrl = userDto.InstagramUrl
        };

        await _db.Users.AddAsync(newUser);
        await _db.SaveChangesAsync();

        return "Data Created!!!";
    }

    public async Task<User> GetUserById(Guid userId)
    {
        var user= await _db.Users.Include(u => u.Posts).Include(u => u.Favourites).FirstOrDefaultAsync(i => i.Id== userId);
        return user;
    }

    public async Task<string> UpdateUser(Guid id,UserDTO userDto)
    {
        var user = await _db.Users.FindAsync(id);
        user.FullName = userDto.FullName;
        user.Username = userDto.Username;
        user.Phone = userDto.Phone;
        user.Location = userDto.Location;
        user.PhotoPath = userDto.PhotoPath;
        user.Dob = userDto.Dob;
        user.Status = userDto.Status;
        user.MasterType = userDto.MasterType;
        user.Bio = userDto.Bio;
        user.Experience = userDto.Experience;
        user.TelegramUrl = userDto.TelegramUrl;
        user.InstagramUrl = userDto.InstagramUrl;
        await _db.SaveChangesAsync();
        return "Data Updated!!!";
    }

    public async Task<string> DeleteUser(Guid id)
    {
        var user = await _db.Users.FindAsync(id);
        _db.Users.Remove(user);
        await _db.SaveChangesAsync();
        return "Data Deleted!!!";
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await _db.Users.Include(u => u.Posts).Include(u => u.Favourites).ToListAsync();
    }
}