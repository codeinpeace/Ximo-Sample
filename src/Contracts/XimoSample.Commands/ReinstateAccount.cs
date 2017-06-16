using System;

namespace XimoSample.Commands
{
    public class ReinstateAccount
    {
        private ReinstateAccount()
        {
        }

        public ReinstateAccount(Guid accountId) : this()
        {
            AccountId = accountId;
        }

        public Guid AccountId { get; }
    }
}