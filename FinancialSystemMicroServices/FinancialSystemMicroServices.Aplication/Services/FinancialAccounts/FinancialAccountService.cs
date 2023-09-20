using FinancialSystemMicroServices.Aplication.Interfaces.FinancialAccounts;
using FinancialSystemMicroServices.Domain.Interfaces.FinancialAccounts;

namespace FinancialSystemMicroServices.Aplication.Services.FinancialAccounts
{
    public class FinancialAccountService : IFinancialAccountService
    {
        private readonly IFinancialAccountRepository _financialAccountRepository;

        public FinancialAccountService(IFinancialAccountRepository financialAccountRepository)
            => _financialAccountRepository = financialAccountRepository;

        public async Task<IEnumerable<FinancialAccount>> GetAll()
            => await _financialAccountRepository.GetAllAsync();

        public async Task<FinancialAccount> GetById(Guid id)
            => await _financialAccountRepository.GetByIdAsync(id);

        public async Task<FinancialAccount> Add(FinancialAccount financialAccount)
            => await _financialAccountRepository.AddAsync(financialAccount);

        public async Task<FinancialAccount> Update(FinancialAccount financialAccount)
            => await _financialAccountRepository.UpdateAsync(financialAccount);

        public void Remove(Guid id)
            => _financialAccountRepository.Remove(id);
    }
}
