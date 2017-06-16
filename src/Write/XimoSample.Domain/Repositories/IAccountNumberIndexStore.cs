using Ximo.Domain;

namespace XimoSample.Domain.Repositories
{
    public interface IAccountNumberIndexStore : IRepository
    {
        int GenerateNewAccountNumber();
    }
}