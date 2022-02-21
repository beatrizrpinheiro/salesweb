using Microsoft.EntityFrameworkCore;
using SalesWeb.Models;

namespace SalesWeb.Data
{
    public class SalesWebContext : DbContext
    {
        public SalesWebContext (DbContextOptions<SalesWebContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
    }
}
