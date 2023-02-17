using WebApi_Jwt.Models;

namespace WebApi_Jwt.Repositories
{
    public class UsersRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>();

            users.Add(new User
            {
                Id = 1, 
                Username = "lucassilva996",
                Password = "@201013#",
                Role = "manager"
            });

            return users.Where(x => x.Username.ToLower() == username && x.Password == x.Password).First();
        }
    }
}
