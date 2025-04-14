using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class CompanyMapping : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Company", schema: "evaluation");

            builder.HasKey(x => x.Id)
                .HasName("PK_COMPANY");

            builder.HasIndex(x => x.CNPJ);
            builder.HasIndex(x => x.CompanyName);

            builder.Property(x => x.CNPJ)
                .IsRequired()
                .HasMaxLength(14);

            builder.Property(x => x.CompanyName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.TradeName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.UpdatedAt);

            builder.HasMany(x => x.Adresses)
                .WithOne()
                .HasForeignKey(x => x.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Phones)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.ContactUser)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
