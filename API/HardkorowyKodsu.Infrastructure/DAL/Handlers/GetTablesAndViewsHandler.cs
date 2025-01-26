using HardkorowyKodsu.Application.Abstractions;
using HardkorowyKodsu.Application.DTO;
using HardkorowyKodsu.Application.Queries;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HardkorowyKodsu.Infrastructure.DAL.Handlers
{
    internal sealed class GetTablesAndViewsHandler : IQueryHandler<GetTablesAndViews, IEnumerable<TableAndViewDto>>
    {
        private readonly HardkorowyKodsuDbContext _dbContext;
        public GetTablesAndViewsHandler(HardkorowyKodsuDbContext dbContext)
            => _dbContext = dbContext;

        public async Task<IEnumerable<TableAndViewDto>> HandleAsync(GetTablesAndViews query)
        {
            using (var connection = _dbContext.Database.GetDbConnection())
            {
                await connection.OpenAsync();

                var tablesAndViews = connection.GetSchema("Tables")
                    .Rows
                    .Cast<DataRow>()
                    .Select(r => new TableAndViewDto
                    {
                        Name = r["TABLE_NAME"].ToString(),
                        Type = r["TABLE_TYPE"].ToString()
                    })
                    .ToList();

                return tablesAndViews;
            }
        }
    }
}
