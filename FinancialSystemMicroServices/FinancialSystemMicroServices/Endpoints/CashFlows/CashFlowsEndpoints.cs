using AutoMapper;
using FinancialSystemMicroServices.Api.Dtos.CashFlows;
using FinancialSystemMicroServices.Aplication.Interfaces.CashFlows;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FinancialSystemMicroServices.Api.Endpoints.CashFlows
{
    public static class CashFlowsEndpoints
    {
        public static void MapCashFlowsEndpoints(this WebApplication app)
        {
            app.MapPost("/CashFlow/ByDateRange",
            [SwaggerResponse(200, "success", Type = typeof(IEnumerable<CashFlowResponse>))]
            [SwaggerResponse(500, "some failure")]
            async ([FromServices] IMapper mapper,[FromServices] ICashFlowService service, [FromBody] CashFlowRequest request) =>
            {
                var results = await service.GetByDateRange(request.InitialDate, request.FinalDate);
                return Results.Json(mapper.Map<IEnumerable<CashFlowResponse>>(results));
            }).WithTags("CashFlows");
        }
    }
}
