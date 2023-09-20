using FinancialSystemMicroServices.Api.Dtos.Clients;
using FinancialSystemMicroServices.Api.Dtos.FinancialAccounts;
using FinancialSystemMicroServices.Domain.Enums;
using Flunt.Notifications;
using Flunt.Validations;
using System.Text.Json.Serialization;

namespace FinancialSystemMicroServices.Api.Dtos.ReceiptsAndPayments
{
    public class CreateReceiptAndPaymentRequest : Notifiable<Notification>
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        public string Type { get; set; } = string.Empty;

        public CreateFinancialAccountRequest FinancialAccount { get; set; }

        public CreateClientRequest? Client { get; set; }

        public string Description { get; set; } = string.Empty;

        public decimal Money { get; set; }

        public DateTime? LaunchDate { get; set; }

        public ReceiptAndPayment MapToModel()
        {
            AddNotifications(new Contract<Notification>()
            .Requires()
                .IsNotNull(Type, "Informe o tipo do lançamento: Payment ou Receipt."));

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNull(FinancialAccount, "Informe a conta financeira para o devido lançamento."));

            AddNotifications(new Contract<Notification>()
            .Requires()
                .IsNotNull(Description, "Informe a descrição do lançamento."));

            AddNotifications(new Contract<Notification>()
            .Requires()
                .IsNotNull(Money, "Informe o valor do lançamento."));

            if (LaunchDate is null)
                LaunchDate = DateTime.UtcNow;

            TypeReceiptOrPaymentEnum TypeEnum = (TypeReceiptOrPaymentEnum)Enum.Parse(typeof(TypeReceiptOrPaymentEnum), Type);

            return new ReceiptAndPayment(Id, TypeEnum, FinancialAccount.MapToModel(), Client?.MapToModel(), Description, Money, (DateTime)LaunchDate);
        }
    }
}
