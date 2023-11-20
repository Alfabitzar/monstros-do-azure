using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Alfabitzar.MonstrosAzure
{
    public static class WebApiUrl
    {
        [FunctionName("web-api-hook")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            return new OkObjectResult(new {
                message = "Hello from Api",
                date = DateTime.Now,
                url = "https://maz055fnapi.azurewebsites.net/api/web-api-hook",
                method = req.Method,
                headers = req.Headers,
                query = req.Query,
                body = await new StreamReader(req.Body).ReadToEndAsync()
            });
        }
    }
}
