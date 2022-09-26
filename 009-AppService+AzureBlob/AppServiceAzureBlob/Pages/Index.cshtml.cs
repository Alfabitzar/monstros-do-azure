using AppServiceAzureBlob.Models;
using AppServiceAzureBlob.Services.Interfaces;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections;

namespace AppServiceBasic.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IBlobService blobService;
        private readonly IQueueService queueService;
        private readonly ITableService tableService;

        public IndexModel(ILogger<IndexModel> logger, IBlobService blobService, IQueueService queueService, ITableService tableService)
        {
            _logger = logger;
            this.blobService = blobService;
            this.queueService = queueService;
            this.tableService = tableService;
        }

        public void OnGet()
        {

        }

        public async Task OnPostUpload()
        {
            foreach (var file in HttpContext.Request.Form.Files)
                await this.blobService.Upload(file.FileName, "files", file.OpenReadStream());
        }

        public async Task OnPostEnqueue()
        {
            await this.queueService.Enqueue("sample-queue", new
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                File = "Index.cshtml.cs",
                Subject = "Test Purpose"
            }); ;
        }

        public async Task OnPostEntity()
        {
            await this.tableService.CreateEntity(nameof(SampleTable), new SampleTable
            {
                PartitionKey = DateTime.Now.ToString("yyyyMMdd"),
                RowKey = Guid.NewGuid().ToString(),
                Description = $"Sample Record on table"
            });
        }
    }
}