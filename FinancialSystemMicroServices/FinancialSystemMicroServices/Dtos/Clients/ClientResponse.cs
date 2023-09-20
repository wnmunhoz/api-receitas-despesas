namespace FinancialSystemMicroServices.Api.Dtos.Clients
{
    public class ClientResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string CellPhone { get; set; } = string.Empty;
    }
}
