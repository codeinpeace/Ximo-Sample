using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ximo.Cqrs;
using Ximo.Cqrs.Decorators;
using Ximo.DependencyInjection;
using XimoSample.DomainEvents;
using XimoSample.Queries;
using XimoSample.Queries.Responses;
using XimoSample.ReadModel.EventHandlers;
using XimoSample.ReadModel.QueryHandlers;

namespace XimoSample.ReadModel
{
    public class ReadModelModule : IModule
    {
        public void Initialize(IServiceCollection builder)
        {
            RegisterContext(builder);
            RegisterEventHandlers(builder);
            RegisterQueryHandlers(builder);
        }

        public IConfiguration Configuration { get; set; }

        private void RegisterContext(IServiceCollection builder)
        {
            builder.AddDbContext<ReadModelContext>(
                options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SampleDatabase")).UseLoggerFactory(null));
        }

        private void RegisterQueryHandlers(IServiceCollection builder)
        {
            builder
                .RegisterQueryHandler
                <GetAccountDetailsById, GetAccountDetailsByIdResponse, GetFullAccountDetailsHandler>();

            builder
                .Decorate
                <IQueryHandler<GetAccountDetailsById, GetAccountDetailsByIdResponse>,
                    LoggingQueryDecorator<GetAccountDetailsById, GetAccountDetailsByIdResponse>>();
        }

        private void RegisterEventHandlers(IServiceCollection builder)
        {
            builder.RegisterDomainEventHandler<AccountCreated, AccountCreatedHandler>();
            builder.RegisterDomainEventHandler<SystemTagAdded, SystemTagAddedHandler>();
            builder.RegisterDomainEventHandler<AddressUpdated, AddressUpdatedHandler>();
            builder.RegisterDomainEventHandler<AccountApproved, AccountApprovedHandler>();
            builder.RegisterDomainEventHandler<AccountDeleted, AccountDeletedHandler>();
        }
    }
}