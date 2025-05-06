using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopOnline.DAL.Entities;

namespace ShopOnline.DAL.Configurations
{
    public class OrderProductConfig : IEntityTypeConfiguration<OrderProductEntity>
    {
        public void Configure(EntityTypeBuilder<OrderProductEntity> builder)
        {
            builder.ToTable("OrderProducts");

            builder.HasKey(op => new { op.OrderId, op.ProductId });

            builder.Property(op => op.Quantity);

            builder.HasOne(op => op.Order)
                   .WithMany(o => o.OrderProducts)
                   .HasForeignKey(op => op.OrderId);

            builder.HasOne(op => op.Product)
                   .WithMany(p => p.OrderProducts)
                   .HasForeignKey(op => op.ProductId);
        }
    }
}
