// Default URL for triggering event grid function in the local environment.
// http://localhost:7071/runtime/webhooks/EventGrid?functionName={functionname}
using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace dotnetfirstapi.Function
{
    public static class dotnetcore_eventgridtrigger
    {
        [Function("dotnetcore_eventgridtrigger")]
        public static void Run([EventGridTrigger] MyEvent input, FunctionContext context)
        {
            var logger = context.GetLogger("dotnetcore_eventgridtrigger");
            logger.LogInformation(input.Data.ToString());
        }
    }

    public class MyEvent
    {
        public string Id { get; set; }

        public string Topic { get; set; }

        public string Subject { get; set; }

        public string EventType { get; set; }

        public DateTime EventTime { get; set; }

        public object Data { get; set; }
    }
}
