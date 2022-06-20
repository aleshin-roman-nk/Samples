using AuthentExample.Model;
using Microsoft.EntityFrameworkCore;

namespace AuthentExample.Service
{
    public class UserContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserOrder> UserOrders { get; set; }

        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
