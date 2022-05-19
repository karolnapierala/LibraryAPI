using libraryAPI.Entities;

namespace libraryAPI
{
    public interface ILibraryService
    {
        Book GetById(int id);
        IEnumerable<Book> GetAll();
        IEnumerable<Book> GetByTitle(string title);
        int Create(Book book);
        void Delete(int id);
        void Update(int id, Book book);
    }
}
