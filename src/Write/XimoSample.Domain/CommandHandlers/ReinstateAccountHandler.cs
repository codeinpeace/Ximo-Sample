using Ximo.Cqrs;
using XimoSample.Commands;
using XimoSample.Domain.Repositories;

namespace XimoSample.Domain.CommandHandlers
{
    internal class ReinstateAccountHandler : ICommandHandler<ReinstateAccount>
    {
        private readonly IAccountStore _accountStore;

        public ReinstateAccountHandler(IAccountStore accountStore)
        {
            _accountStore = accountStore;
        }

        public void Handle(ReinstateAccount command)
        {
            var account = _accountStore.GetById(command.AccountId);
            account.Reinstate();
            _accountStore.Save(account);
        }
    }
}