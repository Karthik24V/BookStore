using BookStore.MongoDBService;
using BookStore.Services.Feature.Books.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Services.Configuration
{
    public static class ServiceConfig
    {
        public static void AddBookStoreService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<DBContext>();
            serviceCollection.AddScoped<IBookService, BookService>();
        }
    }
}

