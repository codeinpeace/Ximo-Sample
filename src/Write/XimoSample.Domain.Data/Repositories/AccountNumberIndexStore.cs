using Ximo.EntityFramework;
using XimoSample.Domain.Data.DataModel;
using XimoSample.Domain.Repositories;

namespace XimoSample.Domain.Data.Repositories
{
    internal class AccountNumberIndexStore : EfRepository<DomainDataContext>, IAccountNumberIndexStore
    {
        public AccountNumberIndexStore(DomainDataContext context) : base(context)
        {
        }

        public int GenerateNewAccountNumber()
        {
            var newRecord = Context.AccountNumberRegistryRecords.Add(new AccountNumberRegistryRecord());
            Context.SaveChanges();
            return newRecord.Entity.AccountNumberId;
        }
    }
}