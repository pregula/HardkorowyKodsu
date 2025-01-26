using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HardkorowyKodsu.Infrastructure.DAL
{
    internal static class Extensions
    {
        private const string _sectionName = "sql";
        public static IServiceCollection AddMSSql(this IServiceCollection services, IConfiguration configuration)
        {
            var section = configuration.GetSection(_sectionName);
            services.Configure<SqlOptions>(opt =>
            {
                section.Bind(opt);
            });
            var options = configuration.GetOptions<SqlOptions>(_sectionName);
            services.AddDbContext<HardkorowyKodsuDbContext>(x => x.UseSqlServer(options.ConnectionString));
            return services;
        }
    }
}
