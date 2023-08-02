using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
   public class Context: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=DESKTOP-CQ6VQ08\SQLEXPRESS;database=YemekTarifCore;integrated security=true;");
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

        }
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasOne(x => x.SenderWriter)
                .WithMany(y => y.WriterSender)
                .HasForeignKey(z => z.SenderID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Message>()
                .HasOne(x => x.ReceiverWriter)
                .WithMany(y => y.WriterReceiver)
                .HasForeignKey(z => z.ReceiverID)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<NewsLetter> NewsLetters{ get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<RecipeRayting> RecipeRaytings{ get; set; }
        public DbSet<Notification> Notifications{ get; set; }
        public DbSet<Message> Messages{ get; set; }
    }
}
