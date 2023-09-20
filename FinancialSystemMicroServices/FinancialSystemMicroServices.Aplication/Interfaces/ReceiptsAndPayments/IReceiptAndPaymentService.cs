namespace FinancialSystemMicroServices.Aplication.Interfaces.ReceiptsAndPayments
{
    public interface IReceiptAndPaymentService
    {
        Task<IEnumerable<ReceiptAndPayment>> GetAll();

        Task<ReceiptAndPayment> GetById(Guid id);

        Task<ReceiptAndPayment> Add(ReceiptAndPayment receiptAndPayment);

        Task<ReceiptAndPayment> Update(ReceiptAndPayment receiptAndPayment);

        void Remove(Guid id);
    }
}
