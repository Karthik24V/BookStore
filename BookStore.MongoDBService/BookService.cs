using BookStore.Domain.Entity;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookStore.MongoDBService
{
    public class BookService : IBookService
    {
        private readonly DBContext _dbContext;
        public BookService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Books>> GetAllBooks()
        {
            var filter = Builders<Books>.Filter.Ne(x => x.Id, "");
            var booksList = await _dbContext._books.Find(filter).ToListAsync();
            return booksList;
        }

        public async Task<Books> GetBooksById(string bookId)
        {
            var filter = Builders<Books>.Filter.Eq(x => x.Id, bookId);
            var book = await _dbContext._books.Find(filter).FirstOrDefaultAsync();
            return book;
        }
        public async Task<List<Books>> SearchBooks(string searchTerm)
        {
            var queryExpr = new BsonRegularExpression(new Regex(searchTerm, RegexOptions.IgnoreCase));
            var filter = Builders<Books>.Filter.Eq("title", queryExpr);
            filter = filter & Builders<Books>.Filter.Or(
                Builders<Books>.Filter.Eq("title", queryExpr), 
                Builders<Books>.Filter.Eq("author", queryExpr));
            //filter = filter & Builders<Books>.Filter.Regex(x => x.Genere, queryExpr);
            //filter = filter & Builders<Books>.Filter.Eq(x => x.Title, searchTerm);
            //filter = filter & Builders<Books>.Filter.Eq(x => x.Author, searchTerm);
            //filter = filter & Builders<Books>.Filter.Eq(x => x.Genere, queryExpr);

            var book = await _dbContext._books.Find(filter).ToListAsync();
            return book;
        }
        public async Task AddBook(Books book)
        {
           await _dbContext._books.InsertOneAsync(book);
        }
        public async Task<object> UpdateBook(Books book)
        {
            var res = await _dbContext._books.ReplaceOneAsync(x=>x.Id == book.Id,book);
            return res;
        }
        public async Task<object> DeleteBook(string bookId)
        {
            var res = await _dbContext._books.DeleteOneAsync(x=>x.Id == bookId);
            return res;
        }
    }
}
