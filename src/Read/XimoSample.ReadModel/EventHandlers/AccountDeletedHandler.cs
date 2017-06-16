using System.Linq;
using Ximo.Domain;
using XimoSample.DomainEvents;

namespace XimoSample.ReadModel.EventHandlers
{
    internal class AccountDeletedHandler : IDomainEventHandler<AccountDeleted>
    {
        private readonly ReadModelContext _modelContext;

        public AccountDeletedHandler(ReadModelContext modelContext)
        {
            _modelContext = modelContext;
        }

        public void Handle(AccountDeleted @event)
        {
            var account = _modelContext.AccountDetails.First(x => x.AccountId == @event.AccountId);
            _modelContext.AccountDetails.Remove(account);

            var systemTags =
                _modelContext.SystemTags.Where(x => x.AccountId == @event.AccountId).ToList();

            foreach (var systemTag in systemTags)
            {
                _modelContext.SystemTags.Remove(systemTag);
            }

            _modelContext.SaveChanges();
        }
    }
}