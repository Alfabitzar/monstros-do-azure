using Azure.Storage.Blobs.Models;

namespace AppServiceAzureBlob.Services.Interfaces;

public interface IBlobService
{
    Task<Uri> Upload(string name, string container, Stream content);
}
