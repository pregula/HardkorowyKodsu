using HardkorowyKodsu.Application.Abstractions;
using HardkorowyKodsu.Application.DTO;

namespace HardkorowyKodsu.Application.Queries
{
    public class GetTablesAndViews : IQuery<IEnumerable<TableAndViewDto>>
    {
    }
}
