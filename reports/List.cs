namespace TodoApi.reports;

internal static class List
{
    public static List<RequestReport> requestReports = new();
}

public class RequestReport{
    public Guid Id {get; set;}
    public string Name {get; set;}
    public string Status {get; set;}
    public DateTime? ProcessedTime {get; set;}
}