using AuthentExample.Model;

namespace AuthentExample.Service.Repos
{
    public class UserOrdersRepo: IUserOrdersRepo
    {
        
        private readonly UserContext _context;
        private readonly IUserInfo _userInfo;

        public UserOrdersRepo(UserContext cont, IUserInfo userInfo)
        {
            _context = cont;
            _userInfo = userInfo;
        }

        public IEnumerable<UserOrder> GetAllOrders()
        {
            return _context.UserOrders.Where(x => x.userid == _userInfo.UID).ToList();
        }
    }
}
