using CathayBkWebAPI.Model;
using Microsoft.EntityFrameworkCore;


namespace CathayBkWebAPI.DataAccess
{
    public class MyDbcentext : DbContext
    {
        public MyDbcentext(DbContextOptions<MyDbcentext> options) : base(options)
        {

        }

        public DbSet<BTCPrice> BTCPrices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
