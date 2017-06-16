using System;

namespace XimoSample.Queries
{
    public class GetAccountDetailsById
    {
        private GetAccountDetailsById()
        {
        }

        public GetAccountDetailsById(Guid accountId) : this()
        {
            AccountId = accountId;
        }

        public Guid AccountId { get; }
    }
}