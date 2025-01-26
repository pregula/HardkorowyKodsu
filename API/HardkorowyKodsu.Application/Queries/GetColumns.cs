using HardkorowyKodsu.Application.Abstractions;
using HardkorowyKodsu.Application.DTO;

namespace HardkorowyKodsu.Application.Queries
{
    public class GetColumns : IQuery<IEnumerable<ColumnDto>>
    {
        public string TableName { get; set; }
    }
}
