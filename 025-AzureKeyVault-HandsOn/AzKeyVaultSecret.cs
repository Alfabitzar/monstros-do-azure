using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace Alfabitzar.MonstrosDoAzure
{
    public static class AzKeyVaultSecret
    {
        [FunctionName("AzKeyVaultSecret")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req, ILogger log)
        {
            try
            {
                // 1- Key vault access
                var VAULT = "https://maz025keyvault.vault.azure.net/";

                // 2- Get Vault Credencial Access
                var client = new SecretClient(new Uri(VAULT), new DefaultAzureCredential());

                // 3- Get the credential from Client
                var hello = (await client.GetSecretAsync("SUPER-SECRET")).Value.Value;

                // 4- Get the password from Client 
                var pswd = (await client.GetSecretAsync("SUPER-PSWD")).Value.Value;

                // 5- Return
                return new OkObjectResult(new {
                    msg = hello,
                    pswd
                });
            }
            catch (Exception ex)
            {
                return new ObjectResult(new {
                    error = ex.Message
                });
            }
        }
    }
}
