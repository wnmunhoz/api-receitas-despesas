public record FinancialAccount(Guid Id, string Name, bool CashAccount)
{
    public FinancialAccount() : this(Guid.NewGuid(), "", false) { }
}