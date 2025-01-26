using Microsoft.AspNetCore.Builder;
using HardkorowyKodsu.Application.Abstractions;
using HardkorowyKodsu.Application.DTO;
using HardkorowyKodsu.Application.Queries;
using HardkorowyKodsu.Infrastructure.DAL;
using HardkorowyKodsu.Infrastructure.DAL.Handlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HardkorowyKodsu.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMSSql(configuration);

            services.AddScoped<IQueryHandler<GetTablesAndViews, IEnumerable<TableAndViewDto>>, GetTablesAndViewsHandler>();
            services.AddScoped<IQueryHandler<GetColumns, IEnumerable<ColumnDto>>, GetColumnsHandler>();

            services.AddControllers();
            return services;
        }

        public static WebApplication UseInfrastructure(this WebApplication app)
        {
            app.MapControllers();
            app.UseHttpsRedirection();
            return app;
        }

        public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
        {
            var options = new T();
            var section = configuration.GetSection(sectionName);
            section.Bind(options);

            return options;
        }
    }
}
