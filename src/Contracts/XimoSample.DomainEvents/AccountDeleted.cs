using System;
using System.Diagnostics.CodeAnalysis;

namespace XimoSample.DomainEvents
{
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
    public class AccountDeleted
    {
        private AccountDeleted()
        {
        }

        public AccountDeleted(Guid accountId, string reason) : this()
        {
            AccountId = accountId;
            Reason = reason;
        }

        public Guid AccountId { get; private set; }
        public string Reason { get; private set; }
    }
}