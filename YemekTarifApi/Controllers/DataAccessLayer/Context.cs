using Microsoft.EntityFrameworkCore;
using YemekTarifApi.Controllers.EntityLayer.Concrete;

namespace YemekTarifApi.Controllers.DataAccessLayer
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=DESKTOP-CQ6VQ08\SQLEXPRESS;database=YemekTarifAPIDB;integrated security=true;TrustServerCertificate=true");

        }
        public DbSet<NewsLetters> NewsLetters { get; set; }
    }
}
