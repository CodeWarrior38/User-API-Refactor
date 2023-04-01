namespace Tests.User.Api.Models
{
    public class UserDto
    {
        public UserDto()
        {
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
    }
}
