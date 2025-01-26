using HardkorowyKodsu.Application.Abstractions;
using HardkorowyKodsu.Application.Queries;
using HardkorowyKodsu.Application.DTO;

namespace HardkorowyKodsu.Client.ViewModels
{
    public class DatabaseViewModel
    {
        private readonly IQueryHandler<GetTablesAndViews, IEnumerable<TableAndViewDto>> _getTablesAndViewsHandler;
        private readonly IQueryHandler<GetColumns, IEnumerable<ColumnDto>> _getColumnsHandler;

        public DatabaseViewModel(IQueryHandler<GetTablesAndViews, IEnumerable<TableAndViewDto>> getTablesAndViewsHandler,
            IQueryHandler<GetColumns, IEnumerable<ColumnDto>> getColumnsHandler)
        {
            _getTablesAndViewsHandler = getTablesAndViewsHandler;
            _getColumnsHandler = getColumnsHandler;
        }

        public async Task<IEnumerable<TableAndViewDto>> GetTablesAndViewsAsync()
        {
            return await _getTablesAndViewsHandler.HandleAsync(new GetTablesAndViews());
        }

        public async Task<IEnumerable<ColumnDto>> GetColumnsAsync(string tableName)
        {
            return await _getColumnsHandler.HandleAsync(new GetColumns() { TableName =  tableName });
        }
    }
}
