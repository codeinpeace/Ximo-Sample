using System.Diagnostics.CodeAnalysis;
using Ximo.Domain;
using Ximo.Validation;

namespace XimoSample.Domain.ValueObejcts
{
    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
    public class AccountStatus : ValueObject<AccountStatus>
    {
        private string _approvedBy;
        private string _deletedReason;

        public AccountStatus(bool isApproved, string approvedBy, bool isDeleted, string deletedReason)
        {
            IsApproved = isApproved;
            _approvedBy = approvedBy;
            IsDeleted = isDeleted;
            _deletedReason = deletedReason;
        }

        public bool IsApproved { get; private set; }

        public string ApprovedBy
        {
            get => _approvedBy;
            private set
            {
                PropertyCheck.MaxLength(value, 100);
                _approvedBy = value;
            }
        }

        public bool IsDeleted { get; private set; }

        public string DeletedReason
        {
            get => _deletedReason;
            private set
            {
                PropertyCheck.MaxLength(value, 100);
                _deletedReason = value;
            }
        }
    }
}