using LibraryManager.Data;
using LibraryManager.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Repository.Injections
{
    public static class RepositoryInjections
    {
        public static void AddPostgres(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<LibraryManagerContext>(options =>
             options.UseNpgsql(configuration.GetConnectionString("LibraryManagerContext")
                   ?? throw new InvalidOperationException("Connection string 'LibraryManagerContext' not found.")));
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            return services;
        }
    }
}
