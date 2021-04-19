using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Text;

namespace dotnetfirstapi.Function
{
    public static class dotnetcore_httptrigger
    {
        [Function("dotnetcore_httptrigger")]
        public static HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("dotnetcore_httptrigger");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            if(req.Method == "GET"){
                response.WriteString("Welcome to Azure Functions!");
            }
            else if(req.Method == "POST"){
                response.WriteString("POST detected: \n");
                response.WriteString("url: " + req.Url + "\n");
                response.WriteString("Body: \n" );

                using (StreamReader reader = new StreamReader(req.Body, Encoding.UTF8))
                {  
                    string line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = reader.ReadLine()) != null)
                    {
                        response.WriteString(line);
                    }
                }
            }
            else{
                response.WriteString("unsupported method: " + req.Method);
            }

            return response;
        }
    }
}
