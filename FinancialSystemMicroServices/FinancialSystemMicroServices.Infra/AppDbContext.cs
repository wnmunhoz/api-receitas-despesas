using FinancialSystemMicroServices.Infra.EF.Clients;
using FinancialSystemMicroServices.Infra.EF.FinancialAccounts;
using FinancialSystemMicroServices.Infra.EF.ReceiptsAndPayments;
using Microsoft.EntityFrameworkCore;

namespace FinancialSystemMicroServices.Infra
{
	public class AppDbContext : DbContext
    {
        public DbSet<FinancialAccount> FinancialAccounts { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ReceiptAndPayment> ReceiptsAndPayments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var directory = Directory.GetCurrentDirectory();

            if (!directory.Contains(".Infra"))
                options.UseSqlite($"DataSource={directory}.Infra\\app.db;Cache=Shared");
            else
                options.UseSqlite($"DataSource={directory}\\app.db;Cache=Shared");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ClientModelMap());
            builder.ApplyConfiguration(new FinancialAccountModelMap());
            builder.ApplyConfiguration(new ReceiptAndPaymentModelMap());

            base.OnModelCreating(builder);
        }
    }
}

