using System.Linq;
using Ximo.Domain;
using XimoSample.DomainEvents;

namespace XimoSample.ReadModel.EventHandlers
{
    internal class AddressUpdatedHandler : IDomainEventHandler<AddressUpdated>
    {
        private readonly ReadModelContext _modelContext;

        public AddressUpdatedHandler(ReadModelContext modelContext)
        {
            _modelContext = modelContext;
        }

        public void Handle(AddressUpdated @event)
        {
            var account = _modelContext.AccountDetails.First(x => x.AccountId == @event.AccountId);
            account.SetAddressDetails(@event);
            _modelContext.SaveChanges();
        }
    }
}