using App.Utils.Extensions.Helpers.PersonalExceptions;
using App.Utils.Middlewares.Configure.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace App.Utils.Middlewares.Core.Middlewares
{
    public class CaptureExceptionsMiddleware
    {
        private readonly RequestDelegate _next;

        public CaptureExceptionsMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (BadRequestException exception)
            {
                await ProcessValidationException(httpContext: httpContext, exception: exception);
            }
            catch (Exception exception)
            {
                await ProcessException(httpContext: httpContext,
                                       titleError: "Internal Server Error",
                                       exception: exception);
            }
        }

        /// <summary>
        /// Process exception.
        /// </summary>
        /// <param name="httpContext">HttpContext object type</param>
        /// <param name="titleError">a string with the error title</param>
        /// <param name="exception">the exception with the information</param>
        public virtual async Task ProcessException(HttpContext httpContext, string titleError, Exception exception)
        {
            await httpContext.Response.WriteAsync(ProblemDetailsExtension.GetProblemDetails(httpContext, titleError, exception));
        }

        /// <summary>
        /// Process Validation Exception
        /// </summary>
        ///<param name="httpContext">HttpContext object type</param>
        /// <param name="exception">a object BadRequestException with te exception information</param>
        public virtual async Task ProcessValidationException(HttpContext httpContext, BadRequestException exception)
        {
            await httpContext.Response.WriteAsync(ProblemDetailsExtension.GetValidationProblemDetails(httpContext, exception));
        }
    }

    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseCaptureExceptionsMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CaptureExceptionsMiddleware>();
        }
    }
}
