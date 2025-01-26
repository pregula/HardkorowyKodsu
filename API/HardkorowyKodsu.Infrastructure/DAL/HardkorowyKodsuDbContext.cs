using Microsoft.EntityFrameworkCore;

namespace HardkorowyKodsu.Infrastructure.DAL
{
    internal sealed class HardkorowyKodsuDbContext : DbContext
    {
        public HardkorowyKodsuDbContext(DbContextOptions<HardkorowyKodsuDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }
    }
}
