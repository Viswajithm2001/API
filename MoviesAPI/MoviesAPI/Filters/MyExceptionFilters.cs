using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MoviesAPI.Filters
{
    public class MyExceptionFilters: ExceptionFilterAttribute
    {
        private readonly ILogger<MyExceptionFilters> _logger;
        public MyExceptionFilters(ILogger<MyExceptionFilters> logger)
        {
            _logger = logger;
        }
        public override void OnException(ExceptionContext context)
        {
            // Code to execute when an exception occurs
            _logger.LogError(context.Exception, $"An error occurred - {context.Exception.Message}");
            context.Result = new ObjectResult(new
            {
                Message = "An error occurred while processing your request.",
                Details = context.Exception.Message
            })
            {
                StatusCode = StatusCodes.Status500InternalServerError // Internal Server Error
            };
            context.ExceptionHandled = true; // Mark the exception as handled
            
        }
    }
}
