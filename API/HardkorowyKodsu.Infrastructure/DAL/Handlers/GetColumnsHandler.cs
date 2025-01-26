using HardkorowyKodsu.Application.Abstractions;
using HardkorowyKodsu.Application.DTO;
using HardkorowyKodsu.Application.Queries;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HardkorowyKodsu.Infrastructure.DAL.Handlers
{
    internal sealed class GetColumnsHandler : IQueryHandler<GetColumns, IEnumerable<ColumnDto>>
    {
        private readonly HardkorowyKodsuDbContext _dbContext;
        public GetColumnsHandler(HardkorowyKodsuDbContext dbContext)
            => _dbContext = dbContext;

        public async Task<IEnumerable<ColumnDto>> HandleAsync(GetColumns query)
        {
            using (var connection = _dbContext.Database.GetDbConnection())
            {
                await connection.OpenAsync();

                var columns = connection.GetSchema("Columns")
                    .Rows
                    .Cast<DataRow>()
                    .Where(r => r["TABLE_NAME"].ToString() == query.TableName)
                    .Select(r => new ColumnDto
                    {
                        Name = r["COLUMN_NAME"].ToString(),
                        Type = r["DATA_TYPE"].ToString()
                    })
                    .ToList();

                return columns;
            }
        }
    }
}
