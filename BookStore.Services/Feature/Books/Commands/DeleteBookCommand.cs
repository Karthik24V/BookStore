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
    public class DeleteBookCommand : DeleteBookViewModel, IRequest<object>
    {
        public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, object>
        {
            private readonly IBookService _bookService;
            public DeleteBookCommandHandler(IBookService bookService)
            {
                _bookService= bookService;
            }

            public async Task<object> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var res = await _bookService.DeleteBook(request.Id);
                    return ApiResponse.OkResponse(res);
                }

                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
