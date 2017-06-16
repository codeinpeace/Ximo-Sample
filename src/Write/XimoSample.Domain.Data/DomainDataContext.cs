using Microsoft.EntityFrameworkCore;
using XimoSample.Domain.Data.DataModel;

namespace XimoSample.Domain.Data
{
    public class DomainDataContext : DbContext
    {
        public DomainDataContext(DbContextOptions<DomainDataContext> options) : base(options)
        {
        }

        public DbSet<AccountNumberRegistryRecord> AccountNumberRegistryRecords { get; set; }
        public DbSet<AccountEvent> AccountEvents { get; set; }
        public DbSet<AccountMemento> AccountSnapshots { get; set; }
    }
}