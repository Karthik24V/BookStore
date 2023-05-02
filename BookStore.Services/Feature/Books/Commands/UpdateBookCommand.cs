using BookStore.Domain;
using BookStore.MongoDBService;
using BookStore.Services.ViewModel.Books;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Feature.Books.Commands
{
    public class UpdateBookCommand : UpdateBookViewModel, IRequest<object>
    {
        public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, object>
        {
            private readonly IBookService _bookService;
            public UpdateBookCommandHandler(IBookService bookService)
            {
                _bookService = bookService;
            }

            public async Task<object> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var newBook = new Domain.Entity.Books();
                    newBook.Id = request.Id;
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
                    var res = await _bookService.UpdateBook(newBook);
                    return ApiResponse.OkResponse(res);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}