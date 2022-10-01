using Microsoft.AspNetCore.Http;

namespace App.Utils.Extensions.Helpers
{
    public static class HttpContextExtension
    {
        /// <summary>
        /// Init response.
        /// </summary>
        /// <param name="httpContext">HttpContext object type</param>
        /// <param name="statusCode">Int object type</param>
        /// <returns>HttpContext object type</returns>
        public static HttpContext InitResponse(this HttpContext httpContext, int statusCode)
        {
            httpContext.Response.Clear();
            httpContext.Response.StatusCode = statusCode;
            httpContext.Response.Headers.Add("Content-Type", "application/json");

            return httpContext;
        }
    }
}
