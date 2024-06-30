using MassTransit;
using TodoApi.bus;
using TodoApi.reports;

namespace TodoApi.controllers;
internal static class ApiEndPoints{

    public static void AddApiEndPoints(this WebApplication app){

        app.MapPost("request-report/{name}",async (string name, IPublishBus bus, CancellationToken ct = default )=> {

            var requested = new RequestReport(){
                Id = Guid.NewGuid(),
                Name = name,
                Status = "Pending",
                ProcessedTime = null
            };

            // Saving the request report on the database
            List.requestReports.Add(requested);

            var eventRequest = new ReportRequestedEvent(requested.Id, requested.Name);

            await bus.PublishAsync(eventRequest, ct);

            return Results.Ok(requested);

        });
        app.MapGet("reports", () => List.requestReports);
    }

}