using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OnlineBankingMVC.Services;

namespace OnlineBankingMVC.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILoggingService loggingService;

        public GlobalExceptionFilter(ILoggingService service)
        {
            loggingService = service;
        }

        public void OnException(ExceptionContext context)
        {
            loggingService.Log(
                $"Exception: {context.Exception.Message}"
            );

            context.Result = new ViewResult
            {
                ViewName = "Error"
            };

            context.ExceptionHandled = true;
        }
    }
}