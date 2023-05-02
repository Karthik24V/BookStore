using MediatR;
using BookStore.Services.Feature.Books.Commands;
using BookStore.Services.Feature.Books.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Services.Configuration
{
    public static class MediatRConfig
    {
        public static void AddMediatRConfig(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(typeof(GetAllBooksQuery.GetAllBooksQueryHandler));
            serviceCollection.AddMediatR(typeof(GetBookByIdQuery.GetBookByIdQueryHandler));
            serviceCollection.AddMediatR(typeof(SearchBookQuery.SearchBookQueryHandler));
            serviceCollection.AddMediatR(typeof(AddBookCommand.AddBookCommandHandler));
            serviceCollection.AddMediatR(typeof(UpdateBookCommand.UpdateBookCommandHandler));
            serviceCollection.AddMediatR(typeof(DeleteBookCommand.DeleteBookCommandHandler));

        }
    }
}

