using Microsoft.EntityFrameworkCore;

namespace DesignPattern.CQRS.DAL
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-V44F1G3; initial catalog=CqrsDesignPattern; integrated security=true");
        }
        public DbSet<Product> Products { get; set; }
    }
}
