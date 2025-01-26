using HardkorowyKodsu.Application.Abstractions;
using HardkorowyKodsu.Application.DTO;
using HardkorowyKodsu.Application.Queries;
using Newtonsoft.Json;

namespace HardkorowyKodsu.Infrastructure.DAL.Handlers
{
    internal sealed class GetColumnsHandler : IQueryHandler<GetColumns, IEnumerable<ColumnDto>>
    {
        private readonly HttpClient _httpClient;
        public GetColumnsHandler(HttpClient httpClient)
            => _httpClient = httpClient;

        public async Task<IEnumerable<ColumnDto>> HandleAsync(GetColumns query)
        {
            var response = await _httpClient.GetAsync($"DatabaseStructure/columns?TableName={query.TableName}");
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ColumnDto>>(content);
        }
    }
}
