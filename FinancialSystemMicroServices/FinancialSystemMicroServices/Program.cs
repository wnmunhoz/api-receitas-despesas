using AutoMapper;
using FinancialSystemMicroServices.Api.Dtos.CashFlows;
using FinancialSystemMicroServices.Api.Dtos.Clients;
using FinancialSystemMicroServices.Api.Dtos.FinancialAccounts;
using FinancialSystemMicroServices.Api.Dtos.ReceiptsAndPayments;
using FinancialSystemMicroServices.Api.Endpoints.CashFlows;
using FinancialSystemMicroServices.Aplication.Interfaces.CashFlows;
using FinancialSystemMicroServices.Aplication.Interfaces.Clients;
using FinancialSystemMicroServices.Aplication.Interfaces.FinancialAccounts;
using FinancialSystemMicroServices.Aplication.Interfaces.ReceiptsAndPayments;
using FinancialSystemMicroServices.Aplication.Services.CashFlows;
using FinancialSystemMicroServices.Aplication.Services.Clients;
using FinancialSystemMicroServices.Aplication.Services.FinancialAccounts;
using FinancialSystemMicroServices.Aplication.Services.ReceiptsAndPayments;
using FinancialSystemMicroServices.Domain.Interfaces.Clients;
using FinancialSystemMicroServices.Domain.Interfaces.FinancialAccounts;
using FinancialSystemMicroServices.Domain.Interfaces.ReceiptsAndPayments;
using FinancialSystemMicroServices.Domain.VOs;
using FinancialSystemMicroServices.Endpoints.Clients;
using FinancialSystemMicroServices.Endpoints.FinancialAccounts;
using FinancialSystemMicroServices.Endpoints.ReceiptsAndPayments;
using FinancialSystemMicroServices.Infra;
using FinancialSystemMicroServices.Infra.Repositories.Clients;
using FinancialSystemMicroServices.Infra.Repositories.FinancialAccounts;
using FinancialSystemMicroServices.Infra.Repositories.ReceiptsAndPayments;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<AppDbContext>();

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.CreateMap<Client, ClientResponse>();
    mc.CreateMap<FinancialAccount, FinancialAccountResponse>();
    mc.CreateMap<ReceiptAndPayment, ReceiptAndPaymentResponse>();
    mc.CreateMap<CashFlowsVO, CashFlowResponse>();
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddTransient<IClientRepository, ClientRepository>();
builder.Services.AddTransient<IClientService, ClientService>();
builder.Services.AddTransient<IFinancialAccountRepository, FinancialAccountRepository>();
builder.Services.AddTransient<IFinancialAccountService, FinancialAccountService>();
builder.Services.AddTransient<IReceiptAndPaymentRepository, ReceiptAndPaymentRepository>();
builder.Services.AddTransient<IReceiptAndPaymentService, ReceiptAndPaymentService>();
builder.Services.AddTransient<ICashFlowService, CashFlowService>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapFinancialAccountsEndpoints();
app.MapClientsEndpoints();
app.MapReceiptsAndPaymentsEndpoints();
app.MapCashFlowsEndpoints();

app.Run();
