using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
   public class Context: IdentityDbContext<AppUser,AppRole,int> //DBContext sınıfından miras alıyor
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=94.138.197.30;database=YemekTarifCore;user=yemeksenle;password=Yemeksenle42");
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

        }
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WriterMessage>()
                .HasOne(x => x.SenderWriter)
                .WithMany(y => y.WriterSender)
                .HasForeignKey(z => z.SenderID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<WriterMessage>()
                .HasOne(x => x.ReceiverWriter)
                .WithMany(y => y.WriterReceiver)
                .HasForeignKey(z => z.ReceiverID)
                .OnDelete(DeleteBehavior.ClientSetNull);



            modelBuilder.Entity<AppUser>()
              .HasIndex(p => p.UserName)
              .IsUnique();

            base.OnModelCreating(modelBuilder);
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
        public DbSet<WriterMessage> Messages { get; set; }
        public DbSet<Admin> Admins{ get; set; }
    }
}
