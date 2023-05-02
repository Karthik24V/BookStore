using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Domain;
using BookStore.MongoDBService;
using BookStore.Services.ViewModel.Books;
using MediatR;

namespace BookStore.Services.Feature.Books.Queries
{
    public class GetBookByIdQuery : GetBookByIdViewModel, IRequest<object>
    {
        public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery,object>
        {
            private readonly IBookService _bookService;
            public GetBookByIdQueryHandler(IBookService bookService)
            {
                _bookService= bookService;
            }

            public async Task<object> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
            {
                var book =await _bookService.GetBooksById(request.Id);
                return ApiResponse.OkResponse(book);
            }
        }
    }
}
