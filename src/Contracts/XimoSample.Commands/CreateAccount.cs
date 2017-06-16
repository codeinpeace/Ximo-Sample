using System;

namespace XimoSample.Commands
{
    public class CreateAccount
    {
        private CreateAccount()
        {
        }

        public CreateAccount(Guid newAccountId, string firstName, string lastName, string businessName,
            string userEmail)
            : this()
        {
            NewAccountId = newAccountId;
            FirstName = firstName;
            LastName = lastName;
            BusinessName = businessName;
            UserEmail = userEmail;
        }

        public Guid NewAccountId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string BusinessName { get; }
        public string UserEmail { get; }
    }
}