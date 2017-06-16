using Ximo.Cqrs;
using XimoSample.Commands;
using XimoSample.Domain.Repositories;

namespace XimoSample.Domain.CommandHandlers
{
    internal class DeleteAccountHandler : ICommandHandler<DeleteAccount>
    {
        private readonly IAccountStore _accountStore;

        public DeleteAccountHandler(IAccountStore accountStore)
        {
            _accountStore = accountStore;
        }

        public void Handle(DeleteAccount command)
        {
            var account = _accountStore.GetById(command.AccountId);
            account.Delete(command.Reason);
            _accountStore.Save(account);
        }
    }
}