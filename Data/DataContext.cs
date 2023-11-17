using Microsoft.EntityFrameworkCore;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Data
{
    public class DataContext : DbContext
    {
         public DataContext(DbContextOptions<DataContext> options) : base(options)
         {

         }
        public DbSet<TrainerUser> Trainers { get; set; }
        public DbSet<Receptionist> Receptionists { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<ManagerS> Managers { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<TrainerSalary> TrainerSalaries { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<RegistrationRequest> RegistrationRequests { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrainerUser>().ToTable("Trainers");
            modelBuilder.Entity<Receptionist>().ToTable("Receptionists");
            modelBuilder.Entity<Administrator>().ToTable("Administrators");
            modelBuilder.Entity<ManagerS>().ToTable("Managers");
            modelBuilder.Entity<Member>().ToTable("Members");
            modelBuilder.Entity<Seller>().ToTable("Sellers");
            modelBuilder.Entity<Sponsor>().ToTable("Sponsors");
        }
        //public DbSet<User> Users { get; set; }
    }
}
