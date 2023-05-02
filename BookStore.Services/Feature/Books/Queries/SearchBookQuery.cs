using BookStore.Domain;
using BookStore.MongoDBService;
using BookStore.Services.ViewModel.Books;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Feature.Books.Queries
{
    public class SearchBookQuery : SearchBookViewModel, IRequest<object>
    {
        public class SearchBookQueryHandler : IRequestHandler<SearchBookQuery, object>
        {
            private readonly IBookService _bookService;
            public SearchBookQueryHandler(IBookService bookService)
            {
                _bookService= bookService;
            }

            public async Task<object> Handle(SearchBookQuery request, CancellationToken cancellationToken)
            {
                var books = await _bookService.SearchBooks(request.Title);
                return ApiResponse.OkResponse(books);
            }
        }
    }
}
