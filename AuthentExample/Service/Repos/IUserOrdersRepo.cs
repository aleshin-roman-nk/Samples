using AuthentExample.Model;

namespace AuthentExample.Service.Repos
{
    public interface IUserOrdersRepo
    {
        IEnumerable<UserOrder> GetAllOrders();
    }
}
