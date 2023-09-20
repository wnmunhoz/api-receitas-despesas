namespace FinancialSystemMicroServices.Aplication.Interfaces.FinancialAccounts
{
    public interface IFinancialAccountService
    {
        Task<IEnumerable<FinancialAccount>> GetAll();

        Task<FinancialAccount> GetById(Guid id);

        Task<FinancialAccount> Add(FinancialAccount financialAccount);

        Task<FinancialAccount> Update(FinancialAccount financialAccount);

        void Remove(Guid id);
    }
}
