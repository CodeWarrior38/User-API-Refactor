using Tests.User.Api.Models;
using Tests.User.Api.Repository;

namespace Tests.User.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserDto> CreateAsync(CreateUserDto dto)
        {         
            var user = await _repository.CreateAsync(dto);
            
            if (user == null)
            {
                return new UserDto();
            }

            return UserDtoFromUser(user);
        }

        public async Task<bool> DeleteAsync(int userId)
        {
            return await _repository.DeleteAsync(userId);
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);

            if (user == null)
            {
                return new UserDto();
            }

            return UserDtoFromUser(user);
        }

        public async Task<UserDto> UpdateAsync(int userId, UpdateUserDto dto)
        {
            var user = await _repository.PutAsync(userId, dto);
            if (user == null)
            {
                return new UserDto();
            }

            return UserDtoFromUser(user);
        }

        public Models.User UserFromCreateDto(CreateUserDto dto)
        {
            return new Models.User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                DateOfBirth = dto.DateOfBirth
            };
        }

        private UserDto UserDtoFromUser(Models.User user)
        {
            return new UserDto()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age
            };
        }
    }
}
