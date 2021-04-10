using System.Diagnostics.CodeAnalysis;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAccess
{
    public class UserRegistrationContext : DbContext
    {
        public UserRegistrationContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        public DbSet<MrGreenUser> MrGreenUsers { get; set; }

        public DbSet<RedBetUser> RedBetUsers { get; set; }

        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Address)
                .WithOne(a => a.User)
                .HasForeignKey<Address>(a => a.UserId);
        }
    }
}