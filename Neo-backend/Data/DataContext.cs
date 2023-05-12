using Microsoft.EntityFrameworkCore;

namespace Neo_backend.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options ) : base (options) { }

        public DbSet<Collaborateur> Collaborateurs { get; set; }
    }
}
 