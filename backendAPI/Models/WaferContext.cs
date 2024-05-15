using Microsoft.EntityFrameworkCore;

namespace backendAPI.Models
{
    public class WaferContext : DbContext
    {
        public WaferContext(DbContextOptions<WaferContext> options)
            : base(options)
        {
        }

        public DbSet<Wafer> Wafers { get; set; }
    }
}