using System;

namespace XimoSample.Commands
{
    public class ApproveAccount
    {
        private ApproveAccount()
        {
        }

        public ApproveAccount(Guid accountId, string approvedBy) : this()
        {
            AccountId = accountId;
            ApprovedBy = approvedBy;
        }

        public Guid AccountId { get; }
        public string ApprovedBy { get; }
    }
}