namespace FinancialSystemMicroServices.Api.Dtos.FinancialAccounts
{
    public class FinancialAccountResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public bool CashAccount { get; set; }
    }
}
