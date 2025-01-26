using System.Configuration;
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
            string apiBaseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];

            services.AddHttpClient<IQueryHandler<GetTablesAndViews, IEnumerable<TableAndViewDto>>, GetTablesAndViewsHandler>((serviceProvider, client) =>
            {
                client.BaseAddress = new Uri(apiBaseUrl);
            });

            services.AddHttpClient<IQueryHandler<GetColumns, IEnumerable<ColumnDto>>, GetColumnsHandler>((serviceProvider, client) =>
            {
                client.BaseAddress = new Uri(apiBaseUrl);
            });

            return services;
        }
    }
}
