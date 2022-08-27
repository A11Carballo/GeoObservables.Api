using GeoObservables.Api.Middleware;

namespace Microsoft.AspNetCore.Builder
{
    public static class LogMiddleware
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseLogMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<Log>();
            
            return builder;
        }
    }
}
