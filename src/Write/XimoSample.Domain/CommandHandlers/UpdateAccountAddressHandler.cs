﻿using Ximo.Cqrs;
using XimoSample.Commands;
using XimoSample.Domain.Repositories;

namespace XimoSample.Domain.CommandHandlers
{
    internal class UpdateAccountAddressHandler : ICommandHandler<UpdateAccountAddress>
    {
        private readonly IAccountStore _accountStore;

        public UpdateAccountAddressHandler(IAccountStore accountStore)
        {
            _accountStore = accountStore;
        }

        public void Handle(UpdateAccountAddress command)
        {
            var account = _accountStore.GetById(command.AccountId);
            account.ChangeAddress(command.AddressLine1, command.AddressLine2, command.City, command.Postcode,
                command.State, command.CountryName);
            _accountStore.Save(account);
        }
    }
}