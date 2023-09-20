using FinancialSystemMicroServices.Domain.Interfaces.FinancialAccounts;
using Microsoft.EntityFrameworkCore;

namespace FinancialSystemMicroServices.Infra.Repositories.FinancialAccounts
{
    public class FinancialAccountRepository : IFinancialAccountRepository
    {
        private AppDbContext _context;

        public FinancialAccountRepository(AppDbContext context)
            => _context = context;

        public async Task<IEnumerable<FinancialAccount>> GetAllAsync()
            => await _context.FinancialAccounts.ToListAsync();

        public async Task<FinancialAccount> GetByIdAsync(Guid id)
        {
            var response = await _context.FinancialAccounts.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

            if (response is null)
                throw new Exception("Financial account not found.");

            return response;
        }

        public async Task<FinancialAccount> AddAsync(FinancialAccount financialAccount)
        {
            var result = await _context.FinancialAccounts.AddAsync(financialAccount);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<FinancialAccount> UpdateAsync(FinancialAccount financialAccount)
        {
            _context.FinancialAccounts.Update(financialAccount);
            await _context.SaveChangesAsync();

            return financialAccount;
        }

        public async void Remove(Guid id)
        {
            var response = await GetByIdAsync(id);

            if (response is not null)
            {
                _context.FinancialAccounts.Remove(response);
                _context.SaveChanges();
            }
        }
    }
}
