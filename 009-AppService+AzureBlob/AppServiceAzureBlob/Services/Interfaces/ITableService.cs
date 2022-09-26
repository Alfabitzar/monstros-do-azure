using Azure.Data.Tables;

namespace AppServiceAzureBlob.Services.Interfaces
{
    public interface ITableService
    {
        Task CreateEntity<T>(string table, T entity) where T : ITableEntity;
    }
}