using App.Utils.Extensions.Helpers;
using App.Utils.Extensions.Helpers.PersonalExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace App.Utils.Middlewares.Configure.Helpers
{
    public static class ProblemDetailsExtension
    {
        /// <summary>
        /// Get a ProblemDetails object in string format
        /// </summary>
        /// <param name="httpContext">HttpContext object type</param>
        /// <param name="exception">the exception with the information</param>
        /// <returns>a string with the json result</returns>
        public static string GetValidationProblemDetails(HttpContext httpContext, BadRequestException exception)
        {
            httpContext = httpContext.InitResponse(StatusCodes.Status400BadRequest);

            var model = new ProblemDetails
            {
                Type = $"https://httpstatuses.com/{httpContext.Response.StatusCode}",
                Title = exception.Message,
                Status = StatusCodes.Status400BadRequest,
                Detail = "Please refer to the errors property for additional details.",
                Instance = httpContext?.Request?.Path
            };

            if (exception.Errors.ErrorCount > 0)
            {
                foreach (KeyValuePair<string, ModelStateEntry> error in exception.Errors)
                {
                    List<string> listErrors = new();
                    error.Value.Errors.ToList().ForEach(x => listErrors.Add(x.ErrorMessage));
                    model.Extensions.Add(error.Key, listErrors);
                }
            }

            return JsonConvert.SerializeObject(model);
        }

        /// <summary>
        /// Get a ProblemDetails object in string format
        /// </summary>
        /// <param name="httpContext">HttpContext object type</param>
        /// <param name="exception">the exception with the information</param>
        /// <returns>a string with the json result</returns>
        public static string GetProblemDetails(HttpContext httpContext, string titleError, Exception exception)
        {
            httpContext = httpContext.InitResponse(StatusCodes.Status500InternalServerError);

            var model = new ProblemDetails
            {
                Type = $"https://httpstatuses.com/{httpContext.Response.StatusCode}",
                Title = titleError,
                Status = StatusCodes.Status500InternalServerError,
                Detail = exception.Message,
                Instance = httpContext?.Request?.Path
            };

            return JsonConvert.SerializeObject(model);
        }
    }
}