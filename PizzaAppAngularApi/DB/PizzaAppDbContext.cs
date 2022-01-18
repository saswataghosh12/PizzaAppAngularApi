using Microsoft.EntityFrameworkCore;
using PizzaAppAngularApi.Models;

namespace PizzaAppAngularApi.DB
{
    public class PizzaAppDbContext : DbContext
    {
        public PizzaAppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<User> User
        {
            get;
            set;
        }

        public DbSet<Pizza> Pizza
        {
            get;
            set;
        }
        public DbSet<Cart> Cart
        {
            get;
            set;
        }
    }
}
