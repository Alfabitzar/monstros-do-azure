using AppServiceAzureBlob.Models;
using AppServiceAzureBlob.Services.Interfaces;
using Azure.Data.Tables;
using Microsoft.Extensions.Options;

namespace AppServiceAzureBlob.Services;

/// <summary>
/// Class to process all the queue operations
/// </summary>
public class AzureTableService : ITableService
{
    private readonly StorageConfiguration config;

    /// <summary>
    /// Default constructor injecting the parameters
    /// </summary>
    /// <param name="config"></param>
    public AzureTableService(IOptions<StorageConfiguration> config)
    {
        this.config = config.Value;

        // Validate if the configuration was provided
        if (string.IsNullOrWhiteSpace(this.config.AccessKey))
            throw new ArgumentNullException("Azure Storage account Key not provided.");
    }


    /// <summary>
    /// Internal method to create the queue reference to manage items
    /// </summary>
    /// <returns></returns>
    private TableClient TableReference(string table)
    {
        // Connect to the storage account's blob endpoint 
        var serviceClient = new TableServiceClient(this.config.AccessKey);

        // Create the blob storage container
        var tableClient = serviceClient.GetTableClient(table);
        tableClient.CreateIfNotExists();

        return tableClient;
    }

    /// <summary>
    /// Method to add a new message to the queue service
    /// </summary>
    /// <param name="queue">Queue name to be added</param>
    /// <param name="data">Data to be added in the queue</param>
    /// <returns></returns>
    public async Task CreateEntity<T>(string table, T entity)
        where T : ITableEntity
    {
        // Get queue reference
        var client = TableReference(table);

        // Send the message to the queue
        await client.AddEntityAsync<T>(entity);
    }
}
