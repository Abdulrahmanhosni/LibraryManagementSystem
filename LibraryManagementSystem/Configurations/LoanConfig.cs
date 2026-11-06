using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagementSystem.Configurations;

public class LoanConfig : IEntityTypeConfiguration<Loan>
{
    public void Configure(EntityTypeBuilder<Loan> builder)
    {
        builder.HasKey(loan => loan.Id);
        builder.Property(loan => loan.LoanDate).IsRequired();
        builder.Property(loan => loan.DueDate).IsRequired();

        builder.HasOne(loan => loan.Book)
            .WithMany(book => book.Loans)
            .HasForeignKey(loan => loan.BookId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(loan => loan.Member)
            .WithMany(member => member.Loans)
            .HasForeignKey(loan => loan.MemberId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}