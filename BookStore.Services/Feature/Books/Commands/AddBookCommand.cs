using BookStore.MongoDBService;
using BookStore.Domain.Entity;
using BookStore.Services.ViewModel.Books;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Domain;

namespace BookStore.Services.Feature.Books.Commands
{
    public class AddBookCommand : CreateBookViewModel, IRequest<object>
    {
        public class AddBookCommandHandler : IRequestHandler<AddBookCommand, object>
        {
            private readonly IBookService _bookService;
            public AddBookCommandHandler(IBookService bookService)
            {
                _bookService = bookService;
            }

            public async Task<object> Handle(AddBookCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var newBook = new Domain.Entity.Books();
                    newBook.ISBN = request.ISBN;
                    newBook.Title = request.Title;
                    newBook.Author = request.Author;
                    newBook.PublicationYear = request.PublicationYear;
                    newBook.Publisher = request.Publisher;
                    newBook.Genere = request.Genere;
                    newBook.Description = request.Description;
                    newBook.Quantity = request.Quantity;
                    newBook.Price = request.Price;
                    newBook.ImageUrl = request.ImageUrl;
                    await _bookService.AddBook(newBook);
                    return ApiResponse.OkResponse();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
