using System.Linq;
using Ximo.Domain;
using XimoSample.DomainEvents;

namespace XimoSample.ReadModel.EventHandlers
{
    internal class AccountApprovedHandler : IDomainEventHandler<AccountApproved>
    {
        private readonly ReadModelContext _modelContext;

        public AccountApprovedHandler(ReadModelContext modelContext)
        {
            _modelContext = modelContext;
        }

        public void Handle(AccountApproved @event)
        {
            var account = _modelContext.AccountDetails.First(x => x.AccountId == @event.AccountId);
            account.SetApproved(@event);
            _modelContext.SaveChangesAsync();
        }
    }
}