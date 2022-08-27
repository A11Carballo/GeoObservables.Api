using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Http.Extensions;

namespace GeoObservables.Api.Middleware
{
    public class Log
    {
        private readonly TelemetryClient _telemetryClient;
        private readonly RequestDelegate _next;
        public Log(RequestDelegate next, TelemetryClient telemetryClient)
        {
            _next = next;
            _telemetryClient = telemetryClient;
        }

        public async Task Invoke(HttpContext context)
        {
            var requestBodyStream = new MemoryStream();
            var originalRequestBody = context.Request.Body;

            await context.Request.Body.CopyToAsync(requestBodyStream);
            requestBodyStream.Seek(0, SeekOrigin.Begin);

            var url = UriHelper.GetDisplayUrl(context.Request);
            var requestBodyText = new StreamReader(requestBodyStream).ReadToEnd();

            requestBodyStream.Seek(0, SeekOrigin.Begin);
            context.Request.Body = requestBodyStream;

            await _next(context);

            context.Request.Body = originalRequestBody;

            Tracerequest(requestBodyText, url, context.Request.Method);


        }


        private void Tracerequest(string payload, string url, string method)
        {

            var telemetry = new TraceTelemetry(url);

            telemetry.Properties.Add("Body", payload);
            telemetry.Properties.Add("Method", method);
            _telemetryClient.TrackTrace(telemetry);
        }
    }
}
