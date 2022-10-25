using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Company.Function
{
    public static class maz013helloazurefn2
    {
        [FunctionName("maz-013-hello-azure-fn-2")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", null, Route = null)] HttpRequest req,
            ILogger log)
        {
            string name = req.Query["name"];
            return new OkObjectResult(new { Name = name });
        }
    }
}
