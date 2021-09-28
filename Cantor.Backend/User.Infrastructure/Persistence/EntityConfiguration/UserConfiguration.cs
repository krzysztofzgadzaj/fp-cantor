using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using User.Application.Entities;

namespace User.Infrastructure.Persistence.EntityConfiguration
{
    public sealed class UserDtoConfiguration : IEntityTypeConfiguration<CantorUser>
    {
        private const string TableName = "Users";
        
        public void Configure(EntityTypeBuilder<CantorUser> builder)
        {
            builder
                .ToTable(TableName)
                .HasKey(user => user.Id);

            builder
                .Property(user => user.Login)
                .HasColumnType("varchar(100)")
                .IsRequired();
            
            builder
                .Property(user => user.Password)
                .HasColumnType("bytea")
                .HasMaxLength(256)
                .IsRequired();
            
            builder
                .Property(user => user.FirstName)
                .HasColumnType("varchar(100)")
                .IsRequired();
            
            builder
                .Property(user => user.SecondName)
                .HasColumnType("varchar(100)")
                .IsRequired();
            
            builder
                .Property(user => user.EmailAddress)
                .HasColumnType("varchar(100)")
                .IsRequired();
        }
    }
}