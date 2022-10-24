using IRZ.Models;
using Microsoft.EntityFrameworkCore;

namespace IRZ.DataBase
{
    public class DataContext : DbContext
    {
        public DbSet<Info> Infos { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
