using ReportingSystem_Assignment1_Code_Day10.Interface;
using ReportingSystem_Assignment1_Code_Day10.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReportingSystem_Assignment1_Code_Day10.Service
{
    internal class ServiceReportGenerator : ReportGenerator
    {
        public Report GenerateReport()
        {
            return new Report
            {
                Title = "Monthly Report",
                Content = "This is the report content"
            };
        }
    }
}
