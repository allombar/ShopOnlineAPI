using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopOnline.DAL.Entities;

public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
               .IsRequired()
               .HasColumnType("NVARCHAR(150)");

        builder.Property(p => p.Description)
               .HasColumnType("NVARCHAR(500)");

        builder.Property(p => p.PriceExclTax)
               .HasColumnType("DECIMAL(10, 2)");

        builder.Property(p => p.StockQuantity)
               .IsRequired();

        builder.HasOne(p => p.Category)
               .WithMany(c => c.Products)
               .HasForeignKey(p => p.CategoryId);
    }
}

