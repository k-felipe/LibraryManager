using LibraryManager.Core.Entities;

namespace LibraryManager.Application.Models
{
    public class UserViewModel
    {
        public UserViewModel(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }

        public static UserViewModel FromEntity(User user)
        {
            return new UserViewModel(user.Name, user.Email);

        }
    }
}
