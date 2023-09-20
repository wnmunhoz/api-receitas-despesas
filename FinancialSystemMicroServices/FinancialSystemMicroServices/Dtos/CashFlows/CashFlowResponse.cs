namespace FinancialSystemMicroServices.Api.Dtos.CashFlows
{
    public class CashFlowResponse
    {
        public decimal Receipts { get; set; }

        public decimal Payments { get; set; }

        public decimal Flows { get; set; }

        public DateTime Day { get; set; }
    }
}
