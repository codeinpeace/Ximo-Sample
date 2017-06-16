using System;

namespace XimoSample.Commands
{
    public class DeleteAccount
    {
        private DeleteAccount()
        {
        }

        public DeleteAccount(Guid accountId, string reason) : this()
        {
            AccountId = accountId;
            Reason = reason;
        }

        public Guid AccountId { get; }
        public string Reason { get; }
    }
}