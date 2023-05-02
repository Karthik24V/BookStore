using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Domain;
using BookStore.MongoDBService;
using MediatR;

namespace BookStore.Services.Feature.Books.Queries
{
    public class GetAllBooksQuery : IRequest<object>
    {
        public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, object>
        {
            private readonly IBookService _bookService;
            public GetAllBooksQueryHandler(IBookService bookService)
            {
                _bookService = bookService;
            }

            public async Task<object> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
            {
                var books = await _bookService.GetAllBooks();
                return ApiResponse.OkResponse(books);
            }
        }
    }
}
