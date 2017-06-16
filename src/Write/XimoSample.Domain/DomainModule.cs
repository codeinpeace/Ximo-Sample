using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ximo.Cqrs;
using Ximo.Cqrs.Decorators;
using Ximo.DependencyInjection;
using XimoSample.Commands;
using XimoSample.Domain.CommandHandlers;
using XimoSample.Domain.DomainServices;
using XimoSample.Domain.EventHandlers;
using XimoSample.DomainEvents;

namespace XimoSample.Domain
{
    public class DomainModule : IModule
    {
        public void Initialize(IServiceCollection builder)
        {
            RegisterDomainServices(builder);
            RegisterCommandHandlers(builder);
            RegisterEventHandlers(builder);
        }

        public IConfiguration Configuration { get; set; }

        private void RegisterCommandHandlers(IServiceCollection builder)
        {
            builder.RegisterCommandHandler<CreateAccount, CreateAccountHandler>();
            builder.Decorate<ICommandHandler<CreateAccount>, LoggingCommandDecorator<CreateAccount>>();
            //If we want DEFAULT tranisent fault handling
            // builder.Decorate<ICommandHandler<CreateAccount>, TransientSqlErrorCommandHandlerDecorator<CreateAccount>>();

            builder.RegisterCommandHandler<UpdateAccountAddress, UpdateAccountAddressHandler>();
            builder.Decorate<ICommandHandler<UpdateAccountAddress>, LoggingCommandDecorator<UpdateAccountAddress>>();

            builder.RegisterCommandHandler<ApproveAccount, ApproveAccountHandler>();
            builder.Decorate<ICommandHandler<ApproveAccount>, LoggingCommandDecorator<ApproveAccount>>();

            builder.RegisterCommandHandler<DeleteAccount, DeleteAccountHandler>();
            builder.Decorate<ICommandHandler<DeleteAccount>, LoggingCommandDecorator<DeleteAccount>>();

            builder.RegisterCommandHandler<ReinstateAccount, ReinstateAccountHandler>();
            builder.Decorate<ICommandHandler<ReinstateAccount>, LoggingCommandDecorator<ReinstateAccount>>();
        }

        private void RegisterDomainServices(IServiceCollection builder)
        {
            builder.AddTransient<IAccountNumberGenerator, AccountNumberGenerator>();
        }

        private void RegisterEventHandlers(IServiceCollection builder)
        {
            builder.RegisterDomainEventHandler<AccountReinstated, AccountReinstatedHandler>();
        }
    }
}