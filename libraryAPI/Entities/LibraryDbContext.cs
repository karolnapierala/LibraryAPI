using Microsoft.EntityFrameworkCore;

namespace libraryAPI.Entities
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }
        private string _connectionString = "Data Source=ACER\\SQLEXPRESS;Database=LibraryDb;Trusted_Connection=True;";
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
