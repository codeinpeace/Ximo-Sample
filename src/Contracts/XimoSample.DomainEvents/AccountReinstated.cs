using System;
using System.Diagnostics.CodeAnalysis;

namespace XimoSample.DomainEvents
{
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
    public class AccountReinstated
    {
        private AccountReinstated()
        {
        }

        public AccountReinstated(Guid accountId) : this()
        {
            AccountId = accountId;
        }

        public Guid AccountId { get; private set; }
    }
}