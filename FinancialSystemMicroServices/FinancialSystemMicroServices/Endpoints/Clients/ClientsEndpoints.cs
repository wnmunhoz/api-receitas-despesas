using AutoMapper;
using FinancialSystemMicroServices.Api.Dtos.Clients;
using FinancialSystemMicroServices.Aplication.Interfaces.Clients;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FinancialSystemMicroServices.Endpoints.Clients
{
    public static class EndpointsClients
    {
        public static void MapClientsEndpoints(this WebApplication app)
        {
            app.MapGet("/Client/GetAll",
            [SwaggerResponse(200, "success", Type = typeof(IEnumerable<ClientResponse>))]
            [SwaggerResponse(500, "some failure")]
            async ([FromServices] IMapper mapper, [FromServices] IClientService service) =>
            {
                var results = await service.GetAll();
                return Results.Json(mapper.Map<IEnumerable<ClientResponse>>(results));
            }).WithTags("Clients");

            app.MapGet("/Client/{Id:Guid}",
            [SwaggerResponse(200, "success", Type = typeof(ClientResponse))]
            [SwaggerResponse(500, "some failure")]
            async ([FromServices] IMapper mapper, [FromServices] IClientService service, Guid id) =>
            {
                var result = await service.GetById(id);
                return Results.Json(mapper.Map<ClientResponse>(result));
            }).WithTags("Clients");

            app.MapPost("/Client",
            [SwaggerResponse(200, "success", Type = typeof(ClientResponse))]
            [SwaggerResponse(500, "some failure")]
            async ([FromServices] IClientService service, [FromBody] CreateClientRequest request) =>
            {
                var client = request.MapToModel();

                if (!request.IsValid)
                    return Results.BadRequest(request.Notifications);

                var response = await service.Add(client);
                return Results.Created($"/v1/Client/{response.Id}", response);

            }).WithTags("Clients");

            app.MapPut("/Client",
            [SwaggerResponse(200, "success", Type = typeof(ClientResponse))]
            [SwaggerResponse(500, "some failure")]
            async ([FromServices] IClientService service, [FromBody] UpdateClientRequest request) =>
            {
                var client = request.MapToModel();

                if (!request.IsValid)
                    return Results.BadRequest(request.Notifications);

                var response = await service.Update(client);
                return Results.Json(response);

            }).WithTags("Clients");

            app.MapDelete("/Client/{Id:Guid}",
            [SwaggerResponse(200, "success")]
            [SwaggerResponse(500, "some failure")]
            ([FromServices] IClientService service, Guid id) =>
            {
                service.Remove(id);
                return Results.Ok();

            }).WithTags("Clients");            
        }
    }
}
