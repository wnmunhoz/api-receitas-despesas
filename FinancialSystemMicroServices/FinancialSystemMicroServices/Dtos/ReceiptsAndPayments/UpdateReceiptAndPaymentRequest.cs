using FinancialSystemMicroServices.Api.Dtos.Clients;
using FinancialSystemMicroServices.Api.Dtos.FinancialAccounts;
using FinancialSystemMicroServices.Domain.Enums;
using Flunt.Notifications;
using Flunt.Validations;

namespace FinancialSystemMicroServices.Api.Dtos.ReceiptsAndPayments
{
    public class UpdateReceiptAndPaymentRequest : Notifiable<Notification>
    {
        public Guid Id { get; set; }

        public string Type { get; set; } = string.Empty;

        public UpdateFinancialAccountRequest FinancialAccount { get; set; }

        public UpdateClientRequest Client { get; set; }

        public string Description { get; set; } = string.Empty;

        public decimal Money { get; set; }

        public DateTime LaunchDate { get; set; }

        public ReceiptAndPayment MapToModel()
        {
            AddNotifications(new Contract<Notification>()
            .Requires()
                .IsNotNull(Type, "Informe o tipo do lançamento: recebimento ou pagamento."));

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNull(FinancialAccount, "Informe a conta financeira para o devido lançamento."));            

            AddNotifications(new Contract<Notification>()
            .Requires()
                .IsNotNull(Description, "Informe a descrição do lançamento."));

            AddNotifications(new Contract<Notification>()
            .Requires()
                .IsNotNull(Money, "Informe o valor do lançamento."));

            TypeReceiptOrPaymentEnum TypeEnum = (TypeReceiptOrPaymentEnum)Enum.Parse(typeof(TypeReceiptOrPaymentEnum), Type);
            
            return new ReceiptAndPayment(Id, TypeEnum, FinancialAccount.MapToModel(), Client.MapToModel(), Description, Money, LaunchDate);
        }
    }
}
