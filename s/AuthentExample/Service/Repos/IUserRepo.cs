using AuthentExample.Model;

namespace AuthentExample.Service.Repos
{
    public interface IUserRepo
    {
        IEnumerable<User> GetAll();
        User Get(string name, string pass);
    }
}
