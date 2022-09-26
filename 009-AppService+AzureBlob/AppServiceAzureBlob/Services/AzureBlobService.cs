using AppServiceAzureBlob.Models;
using AppServiceAzureBlob.Services.Interfaces;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Options;

namespace AppServiceAzureBlob.Services;

/// <summary>
/// Class to hold the instance for the BlobService object
/// </summary>
public class AzureBlobService : IBlobService
{
    private readonly StorageConfiguration config;

    /// <summary>
    /// Default constructor injecting the parameters
    /// </summary>
    /// <param name="config"></param>
    public AzureBlobService(IOptions<StorageConfiguration> config)
    {
        this.config = config.Value;

        // Validate if the configuration was provided
        if (string.IsNullOrWhiteSpace(this.config.AccessKey))
            throw new ArgumentNullException("Azure Storage account Key not provided.");
    }

    /// <summary>
    /// Internal method to create the blob container reference to access items
    /// </summary>
    /// <returns></returns>
    private BlobContainerClient ContainerReference(string container)
    {
        // Connect to the storage account's blob endpoint 
        var blobService = new BlobServiceClient(this.config.AccessKey);

        // Create the blob storage container
        var blobContainer = blobService.GetBlobContainerClient(container);
        blobContainer.CreateIfNotExists(Azure.Storage.Blobs.Models.PublicAccessType.Blob);

        return blobContainer;
    }

    /// <summary>
    /// Method to upload a file to the storage service
    /// </summary>
    /// <param name="name">Item name identification</param>
    /// <param name="content">Content information to be stored in the service</param>
    /// <param name="properties">Additional properties to be stored as metadata information</param>
    /// <returns>Returns object absolute URI</returns>
    public async Task<Uri> Upload(string name, string container, Stream content)
    {
        try
        {
            // Get blob Container reference
            var storageContainer = ContainerReference(container);

            // Get blob object reference
            var blob = storageContainer.GetBlobClient(name);

            // Reset the stream
            content.Seek(0, SeekOrigin.Begin);

            // Upload to the service
            await blob.UploadAsync(content);

            // Return the url
            return blob.Uri;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Write(ex.Message);
            throw;
        }
    }
}