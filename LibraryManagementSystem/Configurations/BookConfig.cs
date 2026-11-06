using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagementSystem.Configurations;

public class BookConfig : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(book => book.Id);
        builder.Property(book => book.Title).IsRequired().HasMaxLength(200);
        builder.Property(book => book.ISBN).IsRequired().HasMaxLength(20);
        builder.HasIndex(book => book.ISBN).IsUnique();
        builder.Property(book => book.PublishedYear).IsRequired();

        builder.HasOne(book => book.Author)
            .WithMany(author => author.Books)
            .HasForeignKey(book => book.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(book => book.Categories)
            .WithMany(category => category.Books);
    }
}
