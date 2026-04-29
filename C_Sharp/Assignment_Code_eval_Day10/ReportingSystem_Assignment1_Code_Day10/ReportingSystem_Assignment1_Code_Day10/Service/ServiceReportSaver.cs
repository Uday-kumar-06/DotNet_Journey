using ReportingSystem_Assignment1_Code_Day10.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReportingSystem_Assignment1_Code_Day10.Service
{
    internal class ServiceReportSaver : ReportSaver
    {
        public void Save(string formattedData)
        {
            File.WriteAllText("report.txt", formattedData);
            Console.WriteLine($"Report saved to file.{formattedData}");
        }
    }
}
