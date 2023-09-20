using FinancialSystemMicroServices.Domain.Enums;

public record ReceiptAndPayment(Guid Id, TypeReceiptOrPaymentEnum? Type, FinancialAccount FinancialAccount, Client? Client, string Description, decimal Money, DateTime LaunchDate)
{
    public ReceiptAndPayment() : this(Guid.NewGuid(), null, new FinancialAccount(), new Client(), "", 0, DateTime.UtcNow) { }
}