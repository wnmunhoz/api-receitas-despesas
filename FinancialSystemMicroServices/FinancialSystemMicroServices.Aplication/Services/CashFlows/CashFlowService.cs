using System;
using FinancialSystemMicroServices.Aplication.Interfaces.CashFlows;
using FinancialSystemMicroServices.Domain.Interfaces.ReceiptsAndPayments;
using FinancialSystemMicroServices.Domain.VOs;

namespace FinancialSystemMicroServices.Aplication.Services.CashFlows
{
	public class CashFlowService : ICashFlowService
    {
        private readonly IReceiptAndPaymentRepository _receiptsAndPaymentsRepository;

		public CashFlowService(IReceiptAndPaymentRepository receiptAndPaymentRepository)		
            => _receiptsAndPaymentsRepository = receiptAndPaymentRepository;		

        public async Task<IEnumerable<CashFlowsVO>> GetByDateRange(DateTime initialDate, DateTime finalDate)
            => await _receiptsAndPaymentsRepository.GetByDateRangeAsync(initialDate, finalDate);
    }
}
