namespace AppServiceAzureBlob.Services.Interfaces;

public interface IQueueService
{
    Task Enqueue(string queue, object data);
}