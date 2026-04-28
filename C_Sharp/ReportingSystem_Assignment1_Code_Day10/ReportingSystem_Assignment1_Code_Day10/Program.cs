using ReportingSystem_Assignment1_Code_Day10.Interface;
using ReportingSystem_Assignment1_Code_Day10.Service;

class Program
{
    static void Main(string[] args)
    {
        ReportGenerator generator = new ServiceReportGenerator();
        ReportFormatter formatter = new ServicePdfFormatter();
        ReportSaver saver = new ServiceReportSaver();

        var reportService = new ReportService(generator, formatter, saver);

        reportService.ProcessReport();
        Console.ReadLine();
    }
}
