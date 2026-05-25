using Microsoft.AspNetCore.Mvc.Filters;
using OnlineBankingMVC.Services;

namespace OnlineBankingMVC.Filters
{
    public class ActionLoggingFilter : ActionFilterAttribute
    {
        private readonly ILoggingService loggingService;

        public ActionLoggingFilter(ILoggingService service)
        {
            loggingService = service;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var user = context.HttpContext.Session.GetString("User");

            var actionName =
                context.ActionDescriptor.DisplayName;

            loggingService.Log(
                $"User: {user} | Action: {actionName} | Time: {DateTime.Now}"
            );

            base.OnActionExecuting(context);
        }
    }
}