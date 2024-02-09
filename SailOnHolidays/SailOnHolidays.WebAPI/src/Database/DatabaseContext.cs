using Microsoft.EntityFrameworkCore;
using SailOnHolidays.Core.src.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SailOnHolidays.WebAPI.src.Database
{
    public class DatabaseContext : DbContext
    {
        private readonly IConfiguration _config;

        public DbSet<User> Users { get; set; }
        public DbSet<Avatar> Avatars { get; set; }
        public DbSet<Yacht> Yachts { get; set; }
        public DbSet<Features> Features { get; set; }
        public DbSet<ConditionsAndTerms> ConditionsAndTerms { get; set; }
        public DbSet<ImageYacht> ImageYachts { get; set; }

        public DatabaseContext(DbContextOptions options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum<Role>();
            modelBuilder.HasPostgresEnum<Status>();

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Role).HasColumnType("role");
                entity.HasIndex(e => e.Email).IsUnique();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}