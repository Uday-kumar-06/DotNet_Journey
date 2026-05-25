using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ECommerceFiltersApp.Services;

namespace ECommerceFiltersApp.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILoggingService _loggingService;

        public ExceptionFilter(ILoggingService loggingService)
        {
            _loggingService = loggingService;
        }

        public void OnException(ExceptionContext context)
        {
            _loggingService.Log(
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