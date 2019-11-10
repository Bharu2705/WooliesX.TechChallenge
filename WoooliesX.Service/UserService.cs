using WooliesX.Model;

namespace WoooliesX.Service
{
    public class UserService : IUserService
    {
        public User GetUserResponse()
        {
            var userResponse = new User() { Name = "Bharathi Ramanarayanan", Token = Constants.Authentication.Token };

            return userResponse;
        }
    }
}
