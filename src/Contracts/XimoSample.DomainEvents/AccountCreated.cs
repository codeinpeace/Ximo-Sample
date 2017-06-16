using System;
using System.Diagnostics.CodeAnalysis;

namespace XimoSample.DomainEvents
{
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
    public class AccountCreated
    {
        private AccountCreated()
        {
        }

        public AccountCreated(Guid accountId, string businessName, int accountNumber) : this()
        {
            AccountNumber = accountNumber;
            BusinessName = businessName;
            AccountId = accountId;
        }

        public Guid AccountId { get; private set; }
        public string BusinessName { get; private set; }
        public int AccountNumber { get; private set; }
    }
}