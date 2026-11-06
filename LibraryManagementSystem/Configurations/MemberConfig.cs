using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagementSystem.Configurations;

public class MemberConfig : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.HasKey(member => member.Id);
        builder.Property(member => member.FullName).IsRequired().HasMaxLength(150);
        builder.Property(member => member.Email).IsRequired().HasMaxLength(150);
        builder.HasIndex(member => member.Email).IsUnique();
        builder.Property(member => member.Phone).IsRequired(false).HasMaxLength(20);
        builder.Property(member => member.MembershipDate).IsRequired();
    }
}
