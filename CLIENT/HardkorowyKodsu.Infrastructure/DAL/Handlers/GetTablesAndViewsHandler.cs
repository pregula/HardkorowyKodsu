using HardkorowyKodsu.Application.Abstractions;
using HardkorowyKodsu.Application.DTO;
using HardkorowyKodsu.Application.Queries;
using Newtonsoft.Json;

namespace HardkorowyKodsu.Infrastructure.DAL.Handlers
{
    internal sealed class GetTablesAndViewsHandler : IQueryHandler<GetTablesAndViews, IEnumerable<TableAndViewDto>>
    {
        private readonly HttpClient _httpClient;
        public GetTablesAndViewsHandler(HttpClient httpClient)
            => _httpClient = httpClient;

        public async Task<IEnumerable<TableAndViewDto>> HandleAsync(GetTablesAndViews query)
        {
            var response = await _httpClient.GetAsync("DatabaseStructure/tables-and-views");
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<TableAndViewDto>>(content);
        }
    }
}
