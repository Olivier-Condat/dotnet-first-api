using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace dotnetfirstapi.Function
{
    public partial class Sensordata
    {
        /// <summary> Initializes a new instance of Sensordata. </summary>
        /// <param name="temperature"> . </param>
        /// <param name="humidity"> . </param>
        public float temperature { get; set;}
        public float humidity { get; set;}
    }

    public static class dotnetcore_eventhubtrigger
    {
        [Function("dotnetcore_eventhubtrigger")]
        public static void Run([EventHubTrigger("samples-workitems", Connection = "AzureEventHubConnectionString")] string[] input, FunctionContext context)
        {
            var logger = context.GetLogger("dotnetcore_eventhubtrigger");

            string intermediate = $"{input[0]}";
            logger.LogInformation($"print debug intermediate version 3: {intermediate}");

            Sensordata data = JsonSerializer.Deserialize<Sensordata>(intermediate);
            
            logger.LogInformation($"find temperature: {data.temperature}");
            logger.LogInformation($"find Humidity: {data.humidity}");
        }
    }
}
