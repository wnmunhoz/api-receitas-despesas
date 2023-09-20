using FinancialSystemMicroServices.Aplication.Interfaces.ReceiptsAndPayments;
using FinancialSystemMicroServices.Domain.Interfaces.FinancialAccounts;
using FinancialSystemMicroServices.Domain.Interfaces.ReceiptsAndPayments;

namespace FinancialSystemMicroServices.Aplication.Services.ReceiptsAndPayments
{
    public class ReceiptAndPaymentService : IReceiptAndPaymentService
    {
        private readonly IReceiptAndPaymentRepository _receiptAndPaymentRepository;

        public ReceiptAndPaymentService(IReceiptAndPaymentRepository receiptAndPaymentRepository)
            => _receiptAndPaymentRepository = receiptAndPaymentRepository;

        public async Task<IEnumerable<ReceiptAndPayment>> GetAll()
            => await _receiptAndPaymentRepository.GetAllAsync();

        public async Task<ReceiptAndPayment> GetById(Guid id)
            => await _receiptAndPaymentRepository.GetByIdAsync(id);

        public async Task<ReceiptAndPayment> Add(ReceiptAndPayment receiptAndPayment)
            => await _receiptAndPaymentRepository.AddAsync(receiptAndPayment);

        public async Task<ReceiptAndPayment> Update(ReceiptAndPayment receiptAndPayment)
            => await _receiptAndPaymentRepository.UpdateAsync(receiptAndPayment);

        public void Remove(Guid id)
            => _receiptAndPaymentRepository.Remove(id);
    }
}
