using AzureFunctions.HandsOn.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AzureFunctions.HandsOn.Functions
{
    public class UploadImage
    {
        private readonly IBlobService blobService;

        /// <summary>
        /// Default constructor to create the function injecting dependecies
        /// </summary>
        /// <param name="blobService"></param>
        public UploadImage(IBlobService blobService)
        {
            this.blobService = blobService;
        }

        /// <summary>
        /// Function to upload a file to the BlobStorage Service
        /// </summary>
        /// <param name="req">Request object instance with all the provided data</param>
        /// <param name="log">Log instance to record messages in log pool</param>
        /// <returns>Returns the status of the message</returns>
        [FunctionName("upload-image")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                // 1- Check if the request send has any content inside
                if (req == null || req.Form.Files.Count == 0)
                    throw new ArgumentNullException(nameof(req.Body), "Content fields should be send.");

                // 2- Save the list of files inside the blob service
                foreach (var file in req.Form.Files)
                    await this.blobService.Upload($"{DateTime.Now:yyyy-MM-dd}/{Guid.NewGuid()}/{file.FileName}", "images", file.ContentType, file.OpenReadStream());

                // 3- Return the object to service
                return new OkObjectResult(new
                {
                    State = "success",
                    DateTime = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                // 4- In case of fail, return the object message
                return new BadRequestObjectResult(new
                {
                    State = "error",
                    DateTime = DateTime.Now,
                    Exception = ex
                });
            }
        }
    }
}
