namespace FinancialSystemMicroServices.Domain.VOs
{
	public class CashFlowsVO : ValueObject
	{
		public CashFlowsVO()
		{
		}

        public CashFlowsVO(decimal receipts, decimal payments, decimal flows, DateTime day)
        {
            Receipts = receipts;
            Payments = payments;
            Flows = flows;
            Day = day;
        }

        public decimal Receipts { get; set; }

		public decimal Payments { get; set; }

		public decimal Flows { get; set; }

        public DateTime Day { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Receipts;

            yield return Payments;

            yield return Flows;

            yield return Day;
        }
    }
}

