using Microsoft.EntityFrameworkCore;

namespace CQRS.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> opts) : base(opts) { }

        public DbSet<Request> Requests { get; set; }
    }

}
