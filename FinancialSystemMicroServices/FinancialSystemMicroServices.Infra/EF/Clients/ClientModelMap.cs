using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialSystemMicroServices.Infra.EF.Clients
{
    public class ClientModelMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");
            builder.HasKey(e => e.Id);

            builder.Property(c => c.Name).HasColumnType("varchar(255)").IsRequired();
            builder.Property(c => c.CellPhone).HasColumnType("varchar(45)").IsRequired();
        }
    }
}
