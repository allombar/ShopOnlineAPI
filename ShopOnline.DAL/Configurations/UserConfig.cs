
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShopOnline.DAL.Entities;

namespace ShopOnline.DAL.Configurations
{
    internal class UserConfig : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");

            builder.Property(u => u.Username)
                   .HasColumnType("NVARCHAR(100)");

            builder.Property(u => u.Email)
                   .HasColumnType("NVARCHAR(255)");

            builder.Property(u => u.Password)
                   .HasColumnType("NVARCHAR(255)");

            builder.Property(u => u.Role)
                   .HasColumnType("NVARCHAR(50)");

            builder.HasIndex(u => u.Email)
                    .HasDatabaseName("UK_Users_Email");
        }
    }
}
