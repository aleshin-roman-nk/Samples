using AuthentExample.Model;

namespace AuthentExample.Service.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly UserContext _cnt;

        public UserRepo(UserContext cnt)
        {
            _cnt = cnt;
        }

        public User Get(string name, string pass)
        {
            return _cnt.Users.FirstOrDefault(x => x.name == name && x.password == pass);
        }

        public IEnumerable<User> GetAll()
        {
            return _cnt.Users.ToList();
        }
    }
}
