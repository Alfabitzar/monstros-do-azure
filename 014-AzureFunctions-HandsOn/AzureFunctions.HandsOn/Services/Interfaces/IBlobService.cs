using System;
using System.IO;
using System.Threading.Tasks;

namespace AzureFunctions.HandsOn.Services.Interfaces
{
    public interface IBlobService
    {
        Task<Uri> Upload(string name, string container, string contentType, Stream content);
    }
}