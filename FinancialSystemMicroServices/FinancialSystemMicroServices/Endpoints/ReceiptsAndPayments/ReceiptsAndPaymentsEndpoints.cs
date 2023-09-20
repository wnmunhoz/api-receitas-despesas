using AutoMapper;
using FinancialSystemMicroServices.Api.Dtos.ReceiptsAndPayments;
using FinancialSystemMicroServices.Aplication.Interfaces.ReceiptsAndPayments;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FinancialSystemMicroServices.Endpoints.ReceiptsAndPayments
{
    public static class ReceiptsAndPaymentsEndpoints
    {
        public static void MapReceiptsAndPaymentsEndpoints(this WebApplication app)
        {
            app.MapGet("/ReceiptAndPayment/GetAll",
            [SwaggerResponse(200, "success", Type = typeof(IEnumerable<ReceiptAndPaymentResponse>))]
            [SwaggerResponse(500, "some failure")]
            async ([FromServices] IMapper mapper, [FromServices] IReceiptAndPaymentService service) =>
            {
                var results = await service.GetAll();
                return Results.Json(mapper.Map<IEnumerable<ReceiptAndPaymentResponse>>(results));
            }).WithTags("ReceiptsAndPayments");

            app.MapGet("/ReceiptAndPayment/{Id:Guid}",
            [SwaggerResponse(200, "success", Type = typeof(ReceiptAndPaymentResponse))]
            [SwaggerResponse(500, "some failure")]
            async ([FromServices] IMapper mapper, [FromServices] IReceiptAndPaymentService service, Guid id) =>
            {
                var result = await service.GetById(id);
                return Results.Json(mapper.Map<ReceiptAndPaymentResponse>(result));
            }).WithTags("ReceiptsAndPayments");

            app.MapPost("/ReceiptAndPayment",
            [SwaggerResponse(200, "success", Type = typeof(ReceiptAndPaymentResponse))]
            [SwaggerResponse(500, "some failure")]
            async ([FromServices] IReceiptAndPaymentService service, [FromBody] CreateReceiptAndPaymentRequest request) =>
            {
                var receiptAndPayment = request.MapToModel();

                if (!request.IsValid)
                    return Results.BadRequest(request.Notifications);

                var response = await service.Add(receiptAndPayment);
                return Results.Created($"/v1/ReceiptAndPayment/{response.Id}", response);

            }).WithTags("ReceiptsAndPayments");

            app.MapPut("/ReceiptAndPayment",
            [SwaggerResponse(200, "success", Type = typeof(ReceiptAndPaymentResponse))]
            [SwaggerResponse(500, "some failure")]
            async ([FromServices] IReceiptAndPaymentService service, [FromBody] UpdateReceiptAndPaymentRequest request) =>
            {
                var financialAccount = request.MapToModel();

                if (!request.IsValid)
                    return Results.BadRequest(request.Notifications);

                var response = await service.Update(financialAccount);
                return Results.Json(response);

            }).WithTags("ReceiptsAndPayments");

            app.MapDelete("/ReceiptAndPayment/{Id:Guid}",
            [SwaggerResponse(200, "success")]
            [SwaggerResponse(500, "some failure")]
            ([FromServices] IReceiptAndPaymentService service, Guid id) =>
            {
                service.Remove(id);
                return Results.Ok();

            }).WithTags("ReceiptsAndPayments");
        }
    }
}
