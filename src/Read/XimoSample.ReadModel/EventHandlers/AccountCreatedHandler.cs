﻿using Ximo.Domain;
using XimoSample.DomainEvents;
using XimoSample.ReadModel.DataModel;

namespace XimoSample.ReadModel.EventHandlers
{
    internal class AccountCreatedHandler : IDomainEventHandler<AccountCreated>
    {
        private readonly ReadModelContext _modelContext;

        public AccountCreatedHandler(ReadModelContext modelContext)
        {
            _modelContext = modelContext;
        }

        public void Handle(AccountCreated @event)
        {
            _modelContext.AccountDetails.Add(new AccountDetails(@event));
            _modelContext.SaveChanges();
        }
    }
}