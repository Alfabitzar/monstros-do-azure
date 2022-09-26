using Azure;
using Azure.Data.Tables;

namespace AppServiceAzureBlob.Models;

public class SampleTable : ITableEntity
{
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public string Description { get; set; }
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }
}
