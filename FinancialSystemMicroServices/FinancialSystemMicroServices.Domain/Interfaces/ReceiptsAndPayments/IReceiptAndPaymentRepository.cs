using FinancialSystemMicroServices.Domain.VOs;

namespace FinancialSystemMicroServices.Domain.Interfaces.ReceiptsAndPayments
{
    public interface IReceiptAndPaymentRepository
    {
        Task<IEnumerable<ReceiptAndPayment>> GetAllAsync();

        Task<ReceiptAndPayment> GetByIdAsync(Guid id);

        Task<ReceiptAndPayment> AddAsync(ReceiptAndPayment receiptAndPayment);

        Task<ReceiptAndPayment> UpdateAsync(ReceiptAndPayment receiptAndPayment);

        void Remove(Guid id);

        Task<IEnumerable<CashFlowsVO>> GetByDateRangeAsync(DateTime initialDate, DateTime finalDate);
    }
}
