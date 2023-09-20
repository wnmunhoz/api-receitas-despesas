using Flunt.Notifications;
using Flunt.Validations;

namespace FinancialSystemMicroServices.Api.Dtos.Clients
{
    public class UpdateClientRequest : Notifiable<Notification>
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string CellPhone { get; set; } = string.Empty;

        public Client MapToModel()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNull(Name, "Informe o nome da conta"));

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNull(CellPhone, "Informe o número do celular"));

            return new Client(Id, Name, CellPhone);
        }
    }
}
