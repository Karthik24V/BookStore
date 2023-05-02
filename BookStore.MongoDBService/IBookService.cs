using BookStore.Domain.Entity;

namespace BookStore.MongoDBService
{
    public interface IBookService
    {
        public Task<List<Books>> GetAllBooks();
        public Task<Books> GetBooksById(string bookId);
        public Task<List<Books>> SearchBooks(string searchTerm);
        public Task<object> UpdateBook(Books book);
        public Task<object> DeleteBook(string bookId);
        public Task AddBook(Books book);
    }
}