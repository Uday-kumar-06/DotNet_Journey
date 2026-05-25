using Microsoft.AspNetCore.Mvc.Filters;
using ECommerceFiltersApp.Services;

namespace ECommerceFiltersApp.Filters
{
    public class LoggingFilter : IActionFilter
    {
        private readonly ILoggingService _loggingService;

        public LoggingFilter(ILoggingService loggingService)
        {
            _loggingService = loggingService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.HttpContext.Request;

            _loggingService.Log(
                $"Request: {request.Method} {request.Path}"
            );
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var response = context.HttpContext.Response;

            _loggingService.Log(
                $"Response Status Code: {response.StatusCode}"
            );
        }
    }
}