using ReportingSystem_Assignment1_Code_Day10.Interface;
using ReportingSystem_Assignment1_Code_Day10.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReportingSystem_Assignment1_Code_Day10.Service
{
    internal class ExcelFormatter: ReportFormatter
    {
        public string Format(Report report)
        {
            return $"EXCEL FORMAT:\n{report.Title}\t{report.Content}";
        }
    }
}
