using ReportingSystem_Assignment1_Code_Day10.Interface;
using ReportingSystem_Assignment1_Code_Day10.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReportingSystem_Assignment1_Code_Day10.Service
{
    internal class ReportService
    {
        private readonly ReportGenerator _generator;
        private readonly ReportFormatter _formatter;
        private readonly ReportSaver _saver;

        public ReportService(
            ReportGenerator generator,
            ReportFormatter formatter,
            ReportSaver saver)
        {
            _generator = generator;
            _formatter = formatter;
            _saver = saver;
        }

        public void ProcessReport()
        {
            Report report = _generator.GenerateReport();
            string formattedData = _formatter.Format(report);
            _saver.Save(formattedData);
        }
    }
}
