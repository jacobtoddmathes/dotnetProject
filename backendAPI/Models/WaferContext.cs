using Microsoft.EntityFrameworkCore;

// import wafer class from Wafer class library
using WaferLibrary;


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