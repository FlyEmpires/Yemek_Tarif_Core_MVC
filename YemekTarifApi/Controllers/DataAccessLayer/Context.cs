using Microsoft.EntityFrameworkCore;

namespace YemekTarifApi.Controllers.DataAccessLayer
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=DESKTOP-CQ6VQ08\SQLEXPRESS;database=YemekTarifCore;integrated security=true;TrustServerCertificate=true");

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
