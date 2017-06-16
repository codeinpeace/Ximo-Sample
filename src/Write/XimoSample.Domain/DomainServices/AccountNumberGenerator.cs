using XimoSample.Domain.Repositories;

namespace XimoSample.Domain.DomainServices
{
    internal class AccountNumberGenerator : IAccountNumberGenerator
    {
        private readonly IAccountNumberIndexStore _accountNumberIndexStore;

        public AccountNumberGenerator(IAccountNumberIndexStore accountNumberIndexStore)
        {
            _accountNumberIndexStore = accountNumberIndexStore;
        }

        public int GenerateAccountNumber()
        {
            return _accountNumberIndexStore.GenerateNewAccountNumber();
        }
    }
}