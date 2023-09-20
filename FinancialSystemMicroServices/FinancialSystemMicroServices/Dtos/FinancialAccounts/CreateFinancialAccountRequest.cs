using Flunt.Notifications;
using Flunt.Validations;
using System.Text.Json.Serialization;

namespace FinancialSystemMicroServices.Api.Dtos.FinancialAccounts
{
    public class CreateFinancialAccountRequest : Notifiable<Notification>
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public bool CashAccount { get; set; }

        public FinancialAccount MapToModel()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNull(Name, "Informe o nome da conta"));

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNull(CashAccount, "Esta é uma conta caixa?"));

            return new FinancialAccount(Id, Name, CashAccount);
        }
    }
}

