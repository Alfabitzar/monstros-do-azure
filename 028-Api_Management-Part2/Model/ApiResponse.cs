using System.Net;
using Newtonsoft.Json;

public class ApiResponse<T>
{
    public HttpStatusCode Code { get; set; }
    public string Message { get; set; }
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public T Data { get; set; }
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string Error{get;set;}
}