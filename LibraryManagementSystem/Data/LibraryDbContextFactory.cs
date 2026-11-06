using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LibraryManagementSystem.Data
{
    public class LibraryDbContextFactory : IDesignTimeDbContextFactory<LibraryDbContext>
    {
        public LibraryDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>()
                .UseSqlServer(DbSettings.ConnectionString)
                .Options;

            return new LibraryDbContext(options);
        }
    }
}
