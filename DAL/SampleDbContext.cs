using Microsoft.EntityFrameworkCore;
using Susteni.Models;

namespace Susteni.DAL
{
    public class SampleDbContext : DbContext
    {
        public SampleDbContext(DbContextOptions<SampleDbContext> options) : base(options) { }

        public DbSet<AuthorizedTenant> AuthorizedTenants { get; set; }
    }
}
