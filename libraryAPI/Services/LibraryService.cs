using libraryAPI.Entities;
using libraryAPI.Exceptions;

namespace libraryAPI.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly LibraryDbContext _dbContext;

        public LibraryService(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Book> GetAll()
        {
            var books = _dbContext
                .Books
                .ToList();
            return books;
        }
        public Book GetById(int id)
        {
            var book = _dbContext
                .Books
                .FirstOrDefault(b => b.Id == id);
            if (book is null)
                throw new NotFoundException("Book not found");
            return book;
        }
        public IEnumerable<Book> GetByTitle(string title)
        {
            IEnumerable<Book> filteredBooks = 
                _dbContext.Books
                .Where(x => x.Title.Contains(title) || x.Autor.Contains(title)).ToList();

            if (filteredBooks is null)
                throw new NotFoundException("Books not found");
            return filteredBooks;
        }
        public int Create(Book book)
        {
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
            return book.Id;
        }

        public void Delete(int id)
        {
            var book = _dbContext
                .Books
                .FirstOrDefault(b => b.Id == id);

            if (book is null)
                throw new NotFoundException("Book not found");

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }

        public void Update(int id, Book book)
        {
            var updatedBook = _dbContext
                .Books
                .FirstOrDefault(b => b.Id == id);

            if (updatedBook is null)
                throw new NotFoundException("Book not found");

            updatedBook.Title = book.Title;
            updatedBook.Autor = book.Autor;
            updatedBook.CreatedDate = book.CreatedDate;

            _dbContext.SaveChanges();
        }
    }
}
