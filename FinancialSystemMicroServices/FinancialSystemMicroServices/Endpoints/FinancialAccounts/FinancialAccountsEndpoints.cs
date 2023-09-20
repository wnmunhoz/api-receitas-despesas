using AutoMapper;
using FinancialSystemMicroServices.Api.Dtos.FinancialAccounts;
using FinancialSystemMicroServices.Aplication.Interfaces.FinancialAccounts;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FinancialSystemMicroServices.Endpoints.FinancialAccounts
{
    public static class EndpointsFinancialAccounts
    {
		public static void MapFinancialAccountsEndpoints(this WebApplication app)
		{
            app.MapGet("/FinancialAccount/GetAll",
            [SwaggerResponse(200, "success", Type = typeof(IEnumerable<FinancialAccountResponse>))]
            [SwaggerResponse(500, "some failure")]
            async ([FromServices] IMapper mapper, [FromServices] IFinancialAccountService service) =>
            {
                var results = await service.GetAll();
                return Results.Json(mapper.Map<IEnumerable<FinancialAccountResponse>>(results));
            }).WithTags("FinancialAccounts");

            app.MapGet("/FinancialAccount/{Id:Guid}",
            [SwaggerResponse(200, "success", Type = typeof(FinancialAccountResponse))]
            [SwaggerResponse(500, "some failure")]
            async ([FromServices] IMapper mapper, [FromServices] IFinancialAccountService service, Guid id) =>
            {
                var result = await service.GetById(id);
                return Results.Json(mapper.Map<FinancialAccountResponse>(result));
            }).WithTags("FinancialAccounts");

            app.MapPost("/FinancialAccount",
            [SwaggerResponse(200, "success", Type = typeof(FinancialAccountResponse))]
            [SwaggerResponse(500, "some failure")]
            async ([FromServices] IFinancialAccountService service, [FromBody] CreateFinancialAccountRequest request) =>
            {
                var financialAccount = request.MapToModel();

                if (!request.IsValid)
                    return Results.BadRequest(request.Notifications);

                var response = await service.Add(financialAccount);
                return Results.Created($"/v1/FinancialAccount/{response.Id}", response);

            }).WithTags("FinancialAccounts");

            app.MapPut("/FinancialAccount",
            [SwaggerResponse(200, "success", Type = typeof(FinancialAccountResponse))]
            [SwaggerResponse(500, "some failure")]
            async ([FromServices] IFinancialAccountService service, [FromBody] UpdateFinancialAccountRequest request) =>
            {
                var financialAccount = request.MapToModel();

                if (!request.IsValid)
                    return Results.BadRequest(request.Notifications);

                var response = await service.Update(financialAccount);
                return Results.Json(response);

            }).WithTags("FinancialAccounts");

            app.MapDelete("/FinancialAccount/{Id:Guid}",
            [SwaggerResponse(200, "success")]
            [SwaggerResponse(500, "some failure")]
            ([FromServices] IFinancialAccountService service, Guid id) =>
            {
                service.Remove(id);
                return Results.Ok();

            }).WithTags("FinancialAccounts");
        }
	}
}

