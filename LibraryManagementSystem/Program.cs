using LibraryManagementSystem.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
try 
{ 
    var options = new DbContextOptionsBuilder<LibraryDbContext>()
        .UseSqlServer(DbSettings.ConnectionString)
        .Options;

    using var context = new LibraryDbContext(options);
    context.Database.Migrate();
    DbSeeder.Seed(context);

    // 1. Retrieve all completed loans (books that have been returned)
    Console.WriteLine("\n--- Currently Borrowed ---");
    var returnedLoans = context.Loans.
                Include(l => l.Book)
                .Include(l => l.Member)
                .Where(l => l.ReturnDate == null)
                .ToList();
    foreach (var loan in returnedLoans)
    {
        Console.WriteLine($"Loan ID: {loan.Id}, Book: {loan.Book.Title}, Member: {loan.Member.FullName}");
    }
    Console.WriteLine("--------------------------------------------------");

    // 2. Retrieve overdue loans (books not yet returned past their due date)
    Console.WriteLine("\n--- Overdue Loans ---");

    var overdueLoans = context.Loans.
                Include(l => l.Book)
                .Include(l => l.Member)
                .Where(l => l.ReturnDate == null && l.DueDate < DateTime.Today)
                .ToList();
    foreach (var loan in overdueLoans)
    {
        Console.WriteLine($"Loan ID: {loan.Id}, Book: {loan.Book.Title}, Member: {loan.Member.FullName}");
    }
    Console.WriteLine("--------------------------------------------------");
    // 3. Retrieve the most borrowed books
    Console.WriteLine("\n--- Most Borrowed Books ---");

    var mostBorrowedBooks = context.Loans
        .Include(l => l.Book)
        .GroupBy(l => l.Book.Title)
        .Select(g => new { Title = g.Key, BorrowCount = g.Count(), })
        .OrderByDescending(b => b.BorrowCount)
        .Take(5)
        .ToList();
    foreach (var book in mostBorrowedBooks)
    {
        Console.WriteLine($"Book: {book.Title}, Borrow Count: {book.BorrowCount}");
    }

    Console.WriteLine("--------------------------------------------------");
    Console.WriteLine("\n--- Members With No Loans ---");
    var membersWithNoLoans = context.Members
     .Where(m => !m.Loans.Any())
     .ToList();
    foreach (var member in membersWithNoLoans)
    {
        Console.WriteLine($"Member with no loans: {member.FullName}");
    }

    Console.WriteLine("--------------------------------------------------");
    Console.WriteLine("\n--- Books Per Author ---");
    var authorBookCounts = context.Books
        .GroupBy(b => b.Author.Name)
        .Select(g => new
        {
            AuthorName = g.Key,
            BookCount = g.Count()
        })
        .ToList();

    foreach (var item in authorBookCounts)
    {
        Console.WriteLine($"Author: {item.AuthorName}, Books Count: {item.BookCount}");
    }

}
catch (SqlException ex)
{
    Console.WriteLine($"Database connection error: {ex.Message}");
}
catch (DbUpdateException ex)
{
    Console.WriteLine($"Error saving data: {ex.InnerException?.Message ?? ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Unexpected error: {ex.Message}");
}
