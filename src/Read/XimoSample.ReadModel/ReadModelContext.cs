using Microsoft.EntityFrameworkCore;
using XimoSample.ReadModel.DataModel;

namespace XimoSample.ReadModel
{
    internal class ReadModelContext : DbContext
    {
        public ReadModelContext(DbContextOptions<ReadModelContext> options) : base(options)
        {
        }

        public DbSet<AccountDetails> AccountDetails { get; set; }
        public DbSet<SystemTag> SystemTags { get; set; }
    }
}