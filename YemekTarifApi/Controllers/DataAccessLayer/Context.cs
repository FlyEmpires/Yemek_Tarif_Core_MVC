using Microsoft.EntityFrameworkCore;
using YemekTarifApi.Controllers.EntityLayer.Concrete;

namespace YemekTarifApi.Controllers.DataAccessLayer
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=DESKTOP-EMG9PNB\SQLEXPRESS;database=YemekTarifAPIDB;integrated security=true;TrustServerCertificate=true");

        }
        public DbSet<NewsLetters> NewsLetters { get; set; }
    }
}
