using Ximo.Cqrs;
using XimoSample.Commands;
using XimoSample.Domain.Repositories;

namespace XimoSample.Domain.CommandHandlers
{
    internal class ApproveAccountHandler : ICommandHandler<ApproveAccount>
    {
        private readonly IAccountStore _accountStore;

        public ApproveAccountHandler(IAccountStore accountStore)
        {
            _accountStore = accountStore;
        }

        public void Handle(ApproveAccount command)
        {
            var account = _accountStore.GetById(command.AccountId);
            account.Approve(command.ApprovedBy);
            _accountStore.Save(account);
        }
    }
}