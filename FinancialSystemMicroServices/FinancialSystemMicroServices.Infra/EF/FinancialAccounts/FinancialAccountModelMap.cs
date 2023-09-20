using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialSystemMicroServices.Infra.EF.FinancialAccounts
{
    public class FinancialAccountModelMap : IEntityTypeConfiguration<FinancialAccount>
    {
        public void Configure(EntityTypeBuilder<FinancialAccount> builder)
        {
            builder.ToTable("FinancialAccount");
            builder.HasKey(e => e.Id);

            builder.Property(c => c.Name).HasColumnType("varchar(255)").IsRequired();
            builder.Property(c => c.CashAccount).HasColumnType("bit(1)").IsRequired();
        }
    }
}
