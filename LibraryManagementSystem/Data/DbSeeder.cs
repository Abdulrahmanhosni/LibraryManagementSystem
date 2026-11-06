using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Data
{
    public static class DbSeeder
    {
        public static void Seed(LibraryDbContext context)
        {
            if (context.Authors.Any())
            {
                Console.WriteLine("Database already has data, skipping seed.");
                return;
            }

            var today = DateTime.Today;

            // Authors
            var orwell = new Author { Name = "George Orwell", Biography = "English novelist and essayist." };
            var mahfouz = new Author { Name = "Naguib Mahfouz", Biography = "Egyptian Nobel laureate novelist." };
            var martin = new Author { Name = "Robert C. Martin", Biography = null };

            // Categories
            var fiction = new Category { Name = "Fiction", Description = "Novels and stories" };
            var politics = new Category { Name = "Politics" };
            var programming = new Category { Name = "Programming" };
            var engineering = new Category { Name = "Software Engineering" };

            // Books
            var book1984 = new Book
            {
                Title = "1984",
                ISBN = "9780451524935",
                PublishedYear = 1949,
                Author = orwell,
                Categories = { fiction, politics }
            };
            var animalFarm = new Book
            {
                Title = "Animal Farm",
                ISBN = "9780451526342",
                PublishedYear = 1945,
                Author = orwell,
                Categories = { fiction, politics }
            };
            var midaq = new Book
            {
                Title = "Midaq Alley",
                ISBN = "9789774247002",
                PublishedYear = 1947,
                Author = mahfouz,
                Categories = { fiction }
            };
            var thief = new Book
            {
                Title = "The Thief and the Dogs",
                ISBN = "9789774248009",
                PublishedYear = 1961,
                Author = mahfouz,
                Categories = { fiction }
            };
            var cleanCode = new Book
            {
                Title = "Clean Code",
                ISBN = "9780132350884",
                PublishedYear = 2008,
                Author = martin,
                Categories = { programming, engineering }
            };
            var cleanArch = new Book
            {
                Title = "Clean Architecture",
                ISBN = "9780134494166",
                PublishedYear = 2017,
                Author = martin,
                Categories = { engineering }
            };

            // Members
            var ahmed = new Member { FullName = "Ahmed Ali", Email = "ahmed@mail.com", Phone = "01000000001", MembershipDate = today.AddDays(-200) };
            var sara = new Member { FullName = "Sara Hassan", Email = "sara@mail.com", Phone = "01000000002", MembershipDate = today.AddDays(-150) };
            var omar = new Member { FullName = "Omar Khaled", Email = "omar@mail.com", Phone = null, MembershipDate = today.AddDays(-90) };
            var mona = new Member { FullName = "Mona Samir", Email = "mona@mail.com", Phone = "01000000004", MembershipDate = today.AddDays(-30) };

            // Loans
            var loans = new List<Loan>
            {

                new() { Book = book1984,   Member = ahmed, LoanDate = today.AddDays(-40), DueDate = today.AddDays(-26), ReturnDate = today.AddDays(-30) },
                new() { Book = cleanCode,  Member = ahmed, LoanDate = today.AddDays(-10), DueDate = today.AddDays(4),   ReturnDate = null },
                new() { Book = cleanArch,  Member = ahmed, LoanDate = today.AddDays(-15), DueDate = today.AddDays(-1),  ReturnDate = null },
                new() { Book = book1984,   Member = sara,  LoanDate = today.AddDays(-20), DueDate = today.AddDays(-6),  ReturnDate = null },
                new() { Book = animalFarm, Member = sara,  LoanDate = today.AddDays(-50), DueDate = today.AddDays(-36), ReturnDate = today.AddDays(-38) },
                new() { Book = cleanCode,  Member = sara,  LoanDate = today.AddDays(-60), DueDate = today.AddDays(-46), ReturnDate = today.AddDays(-50) },
                new() { Book = book1984,   Member = omar,  LoanDate = today.AddDays(-5),  DueDate = today.AddDays(9),   ReturnDate = null },
                new() { Book = midaq,      Member = omar,  LoanDate = today.AddDays(-35), DueDate = today.AddDays(-21), ReturnDate = today.AddDays(-22) },
            };


            context.Loans.AddRange(loans);
            context.Members.Add(mona);
            context.Books.Add(thief);
            context.SaveChanges();

            Console.WriteLine("Seed completed.");

            
        }
    }
}
