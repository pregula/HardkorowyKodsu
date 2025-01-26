using HardkorowyKodsu.Application.Abstractions;
using HardkorowyKodsu.Application.DTO;
using HardkorowyKodsu.Application.Queries;
using HardkorowyKodsu.Infrastructure.DAL.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace HardkorowyKodsu.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddHttpClient<IQueryHandler<GetTablesAndViews, IEnumerable<TableAndViewDto>>, GetTablesAndViewsHandler>((serviceProvider, client) =>
            {
                client.BaseAddress = new Uri("https://localhost:5000");
            });

            services.AddHttpClient<IQueryHandler<GetColumns, IEnumerable<ColumnDto>>, GetColumnsHandler>((serviceProvider, client) =>
            {
                client.BaseAddress = new Uri("https://localhost:5000");
            });

            return services;
        }
    }
}
