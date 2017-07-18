using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Ximo.Cqrs;
using Ximo.DependencyInjection;
using Ximo.Utilities;
using XimoSample.Commands;
using XimoSample.Domain;
using XimoSample.Domain.Data;
using XimoSample.Queries;
using XimoSample.Queries.Responses;
using XimoSample.ReadModel;

namespace SampleRunner
{
    internal class Program
    {
        private static void Main()
        {
            var serviceProvider = Bootstrap();

            var commandBus = serviceProvider.GetRequiredService<ICommandBus>();
            var queryProcessor = serviceProvider.GetRequiredService<IQueryProcessor>();
            SimulateAccountProcessing(commandBus, queryProcessor);

            Console.WriteLine("Sample completed!");
            Console.ReadKey();
        }

        private static void SimulateAccountProcessing(ICommandBus commandBus, IQueryProcessor queryProcessor)
        {
            for (int y = 0; y < 100; y++)
            {
                var newAccountId = Guid.NewGuid();
                var createAccount = new CreateAccount(newAccountId, "Omar", @"Besiso", "ThoughtDesign",
                    RandomGenerator.GenerateRandomEmail());

                try
                {
                    commandBus.Send(createAccount);

                    //Simulate 2 snapshots
                    for (var i = 0; i < 10; i++)
                    {
                        var updateAccount = new UpdateAccountAddress(newAccountId, $"Test {i}", null, null, null, null,
                            "Australia");
                        commandBus.Send(updateAccount);
                    }

                    var approveAccount = new ApproveAccount(newAccountId, "Omar Besiso");
                    commandBus.Send(approveAccount);

                    var deleteAccount = new DeleteAccount(newAccountId, "Testing");
                    commandBus.Send(deleteAccount);

                    var reinstateAccount = new ReinstateAccount(newAccountId);
                    commandBus.Send(reinstateAccount);

                    var query = new GetAccountDetailsById(newAccountId);
                    var response = queryProcessor.ProcessQuery<GetAccountDetailsById, GetAccountDetailsByIdResponse>(query);

                    Console.WriteLine(response.AccountDetailsDto.AccountId);
                    Console.WriteLine(response.AccountDetailsDto.BusinessName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
        }

        private static IServiceProvider Bootstrap()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true);
            IConfiguration configuration = builder.Build();
            serviceCollection.AddSingleton(configuration);

            serviceCollection.AddLogging();

            serviceCollection.RegisterDefaultCommandBus();
            serviceCollection.RegisterDefaultDomainEventBus();
            serviceCollection.RegisterDefaultQueryProcessor();

            serviceCollection.LoadModule<DomainModule>();
            serviceCollection.LoadModule<DomainDataModule>(configuration);
            serviceCollection.LoadModule<ReadModelModule>(configuration);

            var serviceProvider = serviceCollection.BuildServiceProvider();
            serviceProvider.GetService<ILoggerFactory>().AddConsole();


            return serviceProvider;
        }
    }
}