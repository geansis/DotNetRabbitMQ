using MassTransit;
using TodoApi.reports;

namespace TodoApi.bus;

internal sealed class ReportRequestedEventConsumer : IConsumer<ReportRequestedEvent>
{
    private readonly ILogger<ReportRequestedEventConsumer> _logger;

    public ReportRequestedEventConsumer(ILogger<ReportRequestedEventConsumer> logger){
        _logger  = logger;
    }

    public async Task Consume( ConsumeContext<ReportRequestedEvent> context ){
         var message = context.Message;
        _logger.LogInformation("Report processing started Id:{Id}, Name:{Name}", message.Id, message.Name);

        //Delay
        await Task.Delay(10000);

        //Update status and processed time
        var report = List.requestReports.FirstOrDefault(x=>x.Id == message.Id);

        if(report != null)
        {
            report.Status = "Processed";
            report.ProcessedTime = DateTime.Now;
        }

        _logger.LogInformation("Report processed started Id:{Id}, Name:{Name}", message.Id, message.Name);
    }
}