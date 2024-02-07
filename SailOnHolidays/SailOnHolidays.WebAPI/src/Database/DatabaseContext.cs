using Microsoft.EntityFrameworkCore;
using SailOnHolidays.Core.src.Entities;

namespace SailOnHolidays.WebAPI.src.Database
{
    public class DatabaseContext : DbContext
    {
        private readonly IConfiguration _config;

        public DbSet<User> Users { get; set; }

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