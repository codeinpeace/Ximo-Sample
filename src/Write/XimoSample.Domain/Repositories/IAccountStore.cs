using Ximo.EventSourcing;
using XimoSample.Domain.Entities;

namespace XimoSample.Domain.Repositories
{
    public interface IAccountStore : IEventStore<Account>
    {
    }
}