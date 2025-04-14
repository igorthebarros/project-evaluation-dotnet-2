using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", "evaluation");

            builder.HasKey(u => u.Id)
                .HasName("PK_USER");

            builder.HasIndex(x => x.Email);
            builder.HasIndex(x => x.FirstName);
            builder.HasIndex(x => x.LastName);

            builder.Property(u => u.CreatedAt)
                   .IsRequired();

            builder.Property(u => u.UpdatedAt);

            builder.Property(u => u.FirstName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.LastName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(u => u.Password)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(u => u.Phone)
                   .HasMaxLength(20);
        }
    }
}
