using Microsoft.AspNetCore.Mvc.Filters;

namespace MoviesAPI.Filters
{
    public class MyActionFilter: IActionFilter
    {
        private readonly ILogger<MyActionFilter> _logger;
        public MyActionFilter(ILogger<MyActionFilter>logger)
        {
            _logger = logger;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Code to execute before the action executes
            _logger.LogWarning("Action is executing");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Code to execute after the action executes
            _logger.LogWarning("Action is executed");

        }
    }
}
