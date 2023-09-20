using FinancialSystemMicroServices.Domain.Enums;
using FinancialSystemMicroServices.Domain.Interfaces.ReceiptsAndPayments;
using FinancialSystemMicroServices.Domain.VOs;
using Microsoft.EntityFrameworkCore;

namespace FinancialSystemMicroServices.Infra.Repositories.ReceiptsAndPayments
{
    public class ReceiptAndPaymentRepository : IReceiptAndPaymentRepository
    {
        private AppDbContext _context;

        public ReceiptAndPaymentRepository(AppDbContext context)
            => _context = context;

        public async Task<IEnumerable<ReceiptAndPayment>> GetAllAsync()
            => await _context.ReceiptsAndPayments
                    .Include(i => i.FinancialAccount)
                    .Include(i => i.Client)
                    .ToListAsync();

        public async Task<ReceiptAndPayment> GetByIdAsync(Guid id)
        {
            var response = await _context.ReceiptsAndPayments
                                .AsNoTracking()
                                .Include(i => i.FinancialAccount)
                                .Include(i => i.Client)
                                .FirstOrDefaultAsync(c => c.Id == id);

            if (response is null)
                throw new Exception("Financial account not found.");

            return response;
        }

        public async Task<ReceiptAndPayment> AddAsync(ReceiptAndPayment receiptAndPayment)
        {
            var response = await _context.ReceiptsAndPayments.AddAsync(receiptAndPayment);
            await _context.SaveChangesAsync();

            return response.Entity;
        }

        public async Task<ReceiptAndPayment> UpdateAsync(ReceiptAndPayment receiptAndPayment)
        {
            _context.ReceiptsAndPayments.Update(receiptAndPayment);
            await _context.SaveChangesAsync();

            return receiptAndPayment;
        }

        public async void Remove(Guid id)
        {
            var response = await GetByIdAsync(id);

            if (response is not null)
            {
                _context.ReceiptsAndPayments.Remove(response);
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<CashFlowsVO>> GetByDateRangeAsync(DateTime initialDate, DateTime finalDate)
        {
            var response = await _context.ReceiptsAndPayments
                            .Where(w => w.LaunchDate >= Convert.ToDateTime(initialDate.ToString("yyyy-MM-dd 00:00:00")) && w.LaunchDate <= Convert.ToDateTime(finalDate.ToString("yyyy-MM-dd 23:59:59")))
                            .GroupBy(g => new { LauchDate = g.LaunchDate.Date })
                            .Select(s => new CashFlowsVO 
                            {
                                Receipts = (decimal)s.Where(w => w.Type == TypeReceiptOrPaymentEnum.Receipt).Sum(s => (double)s.Money),
                                Payments = (decimal)s.Where(w => w.Type == TypeReceiptOrPaymentEnum.Payment).Sum(s => (double)s.Money),
                                Flows = (decimal)s.Where(w => w.Type == TypeReceiptOrPaymentEnum.Receipt).Sum(s => (double)s.Money) - (decimal)s.Where(w => w.Type == TypeReceiptOrPaymentEnum.Payment).Sum(s => (double)s.Money),
                                Day = s.Key.LauchDate.Date
                            })
                            .OrderBy(o => o.Day)
                            .ToListAsync();

            return response;
        }
    }
}
