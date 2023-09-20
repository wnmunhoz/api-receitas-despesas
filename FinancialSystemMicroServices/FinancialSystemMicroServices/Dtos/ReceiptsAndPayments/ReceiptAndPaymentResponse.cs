namespace FinancialSystemMicroServices.Api.Dtos.ReceiptsAndPayments
{
    public class ReceiptAndPaymentResponse
    {
        public Guid Id { get; set; }

        public string Type { get; set; } = string.Empty;

        public FinancialAccount FinancialAccount { get; set; } = new FinancialAccount();

        public Client Client { get; set; } = new Client();

        public string Description { get; set; } = string.Empty;

        public decimal Money { get; set; }

        public DateTime LaunchDate { get; set; }
    }
}
