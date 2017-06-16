using Ximo.Domain;
using Ximo.EntityFramework.EventSourcing;
using Ximo.EventSourcing;
using XimoSample.Domain.Data.DataModel;
using XimoSample.Domain.Entities;
using XimoSample.Domain.Repositories;

namespace XimoSample.Domain.Data.Repositories
{
    internal class AccountStore : EfEventStore<Account, AccountEvent, DomainDataContext>, IAccountStore
    {
        public AccountStore(DomainDataContext context, IDomainEventBus domainEventBus,
            ISnapshotRepository<Account> snapshotRepository) : base(context, domainEventBus, snapshotRepository)
        {
        }
    }
}