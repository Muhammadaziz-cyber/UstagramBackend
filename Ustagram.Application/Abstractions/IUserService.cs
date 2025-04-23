using Ustagram.Domain.DTOs;
using Ustagram.Domain.Model;

namespace Ustagram.Application.Abstractions;

public interface IUserService
{
    public Task<string> CreateUser(UserDTO userDto);
    public Task<User> GetUserById(Guid  id);
    public Task<string> UpdateUser(Guid id, UserDTO userDto);
    public Task<string> DeleteUser(Guid id);
    public Task<List<User>> GetAllUsers();
}