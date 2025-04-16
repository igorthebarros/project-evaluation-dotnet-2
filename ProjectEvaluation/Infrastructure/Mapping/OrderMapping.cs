using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order", "evaluation");

            builder.HasKey(x => x.Id)
                .HasName("PK_ORDER");

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.UpdatedAt);

            builder.Property(x => x.CompanyId)
                .IsRequired();

            builder.Property(x => x.AddressId)
                .IsRequired();

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.HasMany(x => x.OrderProducts)
                .WithOne()
                .HasForeignKey(x => x.Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
