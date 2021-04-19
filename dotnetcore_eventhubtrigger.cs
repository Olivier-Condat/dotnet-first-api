using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace dotnetfirstapi.Function
{
    public static class dotnetcore_eventhubtrigger
    {
        [Function("dotnetcore_eventhubtrigger")]
        public static void Run([EventHubTrigger("samples-workitems", Connection = "AzureEventHubConnectionString")] string[] input, FunctionContext context)
        {
            var logger = context.GetLogger("dotnetcore_eventhubtrigger");
            logger.LogInformation($"First Event Hubs triggered message: {input[0]}");
        }
    }
}
