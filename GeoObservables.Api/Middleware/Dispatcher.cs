namespace GeoObservables.Api.Middleware
{
    public class Dispatcher
    {
        private readonly RequestDelegate _next;
        public Dispatcher(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
           await _next(context);
        }

    }
}
