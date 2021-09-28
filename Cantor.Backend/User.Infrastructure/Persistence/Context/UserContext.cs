using System.Reflection;
using Microsoft.EntityFrameworkCore;
using User.Application.Entities;

namespace User.Infrastructure.Persistence.Context
{
    public sealed class UserContext : DbContext
    {
        public const string SchemaName = "Users";

        public UserContext(DbContextOptions<UserContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }
        
        public DbSet<CantorUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
                
            modelBuilder
                .Entity<CantorUser>()
                .HasIndex(x => x.Login)
                .IsUnique();
            
            modelBuilder
                .Entity<CantorUser>()
                .HasIndex(x => x.EmailAddress)
                .IsUnique();
        }
    }
}