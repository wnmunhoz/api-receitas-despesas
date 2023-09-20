namespace FinancialSystemMicroServices.Domain.Interfaces.FinancialAccounts
{
    public interface IFinancialAccountRepository
    {
        Task<IEnumerable<FinancialAccount>> GetAllAsync();

        Task<FinancialAccount> GetByIdAsync(Guid id);

        Task<FinancialAccount> AddAsync(FinancialAccount financialAccount);

        Task<FinancialAccount> UpdateAsync(FinancialAccount financialAccount);

        void Remove(Guid id);
    }
}
