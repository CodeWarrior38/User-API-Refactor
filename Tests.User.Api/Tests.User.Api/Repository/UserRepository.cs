using Microsoft.EntityFrameworkCore;
using Tests.User.Api.Models;

namespace Tests.User.Api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _db;

        public UserRepository(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<Models.User?> CreateAsync(CreateUserDto dto)
        {
            if (dto == null)
            {
                return new Models.User();
            }

            var userToAdd = new Models.User()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                DateOfBirth = dto.DateOfBirth
            };

            await _db.Users.AddAsync(userToAdd);

            if (await _db.SaveChangesAsync() > 0)
            {
                return userToAdd;
            }

            return default;
        }

        public async Task<bool> DeleteAsync(int userId)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null)
            {
                return false;
            }

            _db.Users.Remove(user); 
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<Models.User?> GetByIdAsync(int id)
        {
            return await _db.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Models.User?> PutAsync(int userId, UpdateUserDto dto)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x=> x.Id == userId);
            if (user == null)
            {
                return null;
            }

            //user now loaded and being tracked by context so change properties
            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.DateOfBirth = dto.DateOfBirth;

            if (await _db.SaveChangesAsync() > 0)
            { 
                return user;
            }

            return null;
        }
    }
}
