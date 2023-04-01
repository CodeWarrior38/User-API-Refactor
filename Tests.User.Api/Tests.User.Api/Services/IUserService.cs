using Tests.User.Api.Models;

namespace Tests.User.Api.Services
{
    public interface IUserService
    {
        Task<UserDto> GetUserByIdAsync(int id);
        Task<UserDto> CreateAsync(CreateUserDto dto);
        Task<UserDto> UpdateAsync(int userId, UpdateUserDto dto);
        Task<bool> DeleteAsync(int userId);
    }
}
