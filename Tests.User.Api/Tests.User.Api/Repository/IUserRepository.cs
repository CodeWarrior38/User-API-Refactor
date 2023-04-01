using Tests.User.Api.Models;

namespace Tests.User.Api.Repository
{
    public interface IUserRepository
    {
        Task<Models.User> GetByIdAsync(int id);
        Task<Models.User?> CreateAsync(CreateUserDto dto);
        Task<Models.User?> PutAsync(int userId, UpdateUserDto dto);
        Task<bool> DeleteAsync(int userId);
    }
}
