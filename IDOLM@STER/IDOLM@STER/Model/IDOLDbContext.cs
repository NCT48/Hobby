using System.Data.Entity;

namespace Models.Master
{
    public class IDOLDbContext : DbContext
    {
        public IDOLDbContext()
            : base("name=IDOLDbContext")
        {
        }

        public DbSet<IDOLJson> IDOLs { get; set; }
    }
}