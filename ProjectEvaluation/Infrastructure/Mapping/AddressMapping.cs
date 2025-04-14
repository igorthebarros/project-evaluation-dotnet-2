using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address", schema: "evaluation");

            builder.HasKey(x => x.Id)
                .HasName("PK_ADDRESS");

            builder.HasIndex(a => a.PostalCode);

            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(a => a.StreetName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(a => a.Number)
                .IsRequired();

            builder.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Neighborhood)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.PostalCode)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(a => a.CreatedAt)
                .IsRequired();

            builder.Property(a => a.UpdatedAt);
        }
    }
}
