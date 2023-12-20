using Microsoft.EntityFrameworkCore;
using WebApp_AIK2_Pluhar.Models;

namespace WebApp_AIK2_Pluhar.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {
        }

        public DbSet<Credit> Credits { get; set; }  

    }
}
