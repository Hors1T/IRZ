using IRZ.Models;
using Microsoft.EntityFrameworkCore;

namespace IRZ.DataBase
{
    public class DataContext : DbContext
    {
        public DbSet<Owner> Cars { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
