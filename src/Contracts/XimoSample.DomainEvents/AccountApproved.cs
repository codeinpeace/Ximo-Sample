using System;
using System.Diagnostics.CodeAnalysis;

namespace XimoSample.DomainEvents
{
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
    public class AccountApproved
    {
        private AccountApproved()
        {
        }

        public AccountApproved(Guid accountId, string approvedBy) : this()
        {
            AccountId = accountId;
            ApprovedBy = approvedBy;
        }

        public Guid AccountId { get; private set; }
        public string ApprovedBy { get; private set; }
    }
}