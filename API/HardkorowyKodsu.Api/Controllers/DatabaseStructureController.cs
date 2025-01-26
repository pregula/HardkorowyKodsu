using HardkorowyKodsu.Application.Abstractions;
using HardkorowyKodsu.Application.DTO;
using HardkorowyKodsu.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace HardkorowyKodsu.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DatabaseStructureController : Controller
    {
        private readonly IQueryHandler<GetTablesAndViews, IEnumerable<TableAndViewDto>> _getTablesAndViewsHandler;
        private readonly IQueryHandler<GetColumns, IEnumerable<ColumnDto>> _getColumnsHandler;

        public DatabaseStructureController(IQueryHandler<GetTablesAndViews, IEnumerable<TableAndViewDto>> getTablesAndViewsHandler,
            IQueryHandler<GetColumns, IEnumerable<ColumnDto>> getColumnsHandler)
        {
            _getTablesAndViewsHandler = getTablesAndViewsHandler;
            _getColumnsHandler = getColumnsHandler;
        }

        [HttpGet("tables-and-views")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<TableAndViewDto>>> Get()
            => Ok(await _getTablesAndViewsHandler.HandleAsync(new GetTablesAndViews()));

        [HttpGet("columns")]
        public async Task<ActionResult<IEnumerable<ColumnDto>>> Get([FromQuery] GetColumns query)
            => Ok(await _getColumnsHandler.HandleAsync(query));
    }
}
