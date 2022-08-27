using GeoObservables.Api.Middleware;

namespace Microsoft.AspNetCore.Builder
{
    public static class DispatcherMiddleware
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseDispatcherMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<Dispatcher>();
            
            return builder;
        }
    }
}
