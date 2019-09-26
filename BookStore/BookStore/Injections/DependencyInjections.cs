using BookStore.Business;
using BookStore.Business.Interface;
using BookStore.Data.Context;
using BookStore.Data.Interface;
using BookStore.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Api.Injections
{
    public static class DependencyInjections
    {
        public static void AddDependencyInjections(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddSingleton<DataContext>();
        }
    }
}
