using System.ComponentModel.DataAnnotations.Schema;
using Ximo.EntityFramework.EventSourcing;
using XimoSample.Domain.Entities;

namespace XimoSample.Domain.Data.DataModel
{
    [Table("AccountSnapshot", Schema = "Write")]
    public class AccountMemento : EfAggregateMemento
    {
        internal AccountMemento()
        {
        }

        public AccountMemento(Account account) : base(account)
        {
        }
    }
}