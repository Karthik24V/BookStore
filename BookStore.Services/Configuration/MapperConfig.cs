using AutoMapper;
using BookStore.Services.Configuration.ProfileMapper;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Services.Configuration
{
    public static class MapperConfig
    {
        public static void AddAutoMapper(this IServiceCollection serviceCollection)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new BookProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            serviceCollection.AddSingleton(mapper);
        }
    }
}

