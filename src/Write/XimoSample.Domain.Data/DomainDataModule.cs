using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ximo.DependencyInjection;
using Ximo.EntityFramework.EventSourcing;
using Ximo.EventSourcing;
using XimoSample.Domain.Data.DataModel;
using XimoSample.Domain.Data.Repositories;
using XimoSample.Domain.Entities;
using XimoSample.Domain.Repositories;

namespace XimoSample.Domain.Data
{
    public class DomainDataModule : IModule
    {
        public void Initialize(IServiceCollection builder)
        {
            RegisterContext(builder);
            RegisterRepositories(builder);
        }

        public IConfiguration Configuration { private get; set; }

        private void RegisterContext(IServiceCollection builder)
        {
            var connectionString = Configuration.GetConnectionString("SampleDatabase");
            builder.AddDbContext<DomainDataContext>(
                options => options.UseSqlServer(connectionString).UseLoggerFactory(null));
        }

        private static void RegisterRepositories(IServiceCollection builder)
        {
            builder.AddTransient<IAccountNumberIndexStore, AccountNumberIndexStore>();
            builder.AddTransient<IAccountStore, AccountStore>();
            builder
                .AddTransient
                <ISnapshotRepository<Account>, EfSnapshotRepository<Account, AccountMemento, DomainDataContext>>();
        }
    }
}