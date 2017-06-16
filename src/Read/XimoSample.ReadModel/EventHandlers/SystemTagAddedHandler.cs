using Ximo.Domain;
using XimoSample.DomainEvents;
using XimoSample.ReadModel.DataModel;

namespace XimoSample.ReadModel.EventHandlers
{
    internal class SystemTagAddedHandler : IDomainEventHandler<SystemTagAdded>
    {
        private readonly ReadModelContext _modelContext;

        public SystemTagAddedHandler(ReadModelContext modelContext)
        {
            _modelContext = modelContext;
        }

        public void Handle(SystemTagAdded @event)
        {
            _modelContext.SystemTags.Add(new SystemTag(@event));
            _modelContext.SaveChanges();
        }
    }
}