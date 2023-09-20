using FinancialSystemMicroServices.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialSystemMicroServices.Infra.EF.ReceiptsAndPayments
{
    public class ReceiptAndPaymentModelMap : IEntityTypeConfiguration<ReceiptAndPayment>
    {
        public void Configure(EntityTypeBuilder<ReceiptAndPayment> builder)
        {
            builder.ToTable("ReceiptAndPayment");
            builder.HasKey(e => e.Id);

            builder.Property(c => c.Type)
                .HasConversion(
                v => v.ToString(),
                v => (TypeReceiptOrPaymentEnum)Enum.Parse(typeof(TypeReceiptOrPaymentEnum), v));

            builder
                .HasOne(p => p.FinancialAccount)
                .WithMany()
                .HasForeignKey("FinancialAccountId")
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(p => p.Client)
                .WithMany()
                .HasForeignKey("ClientId")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(c => c.Description).HasColumnType("varchar(255)").IsRequired();
        }
    }
}
