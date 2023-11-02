using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alfabitzar.SampleDb
{
    public static class ListCustomers
    {
        [FunctionName("list-customers")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            // Call the method to get the customers
            var customers = await GetCustomersAsync();

            // Return
            return new OkObjectResult(customers);
        }

        // Method to connect in sql server and get salesltcustomer model
        private static async Task<List<SalesLTCustomer>> GetCustomersAsync()
        {
            // Connect to the database connection
            using var sqlConnection = new SqlConnection(Environment.GetEnvironmentVariable("SqlConnectionString"));
            await sqlConnection.OpenAsync();

            // Create a command to execute the query
            using var sqlCommand = new SqlCommand("SELECT TOP 20 * FROM SalesLT.Customer ORDER BY NEWID()", sqlConnection);
            using var sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            // Bind the reader with the model
            var customers = new List<SalesLTCustomer>();
            while (await sqlDataReader.ReadAsync())
            {
                customers.Add(new SalesLTCustomer
                {
                    CustomerID = sqlDataReader.GetInt32(0),
                    NameStyle = sqlDataReader.GetBoolean(1),
                    Title = sqlDataReader.GetSafeString(2),
                    FirstName = sqlDataReader.GetSafeString(3),
                    MiddleName = sqlDataReader.GetSafeString(4),
                    LastName = sqlDataReader.GetSafeString(5),
                    Suffix = sqlDataReader.GetSafeString(6),
                    CompanyName = sqlDataReader.GetSafeString(7),
                    SalesPerson = sqlDataReader.GetSafeString(8),
                    EmailAddress = sqlDataReader.GetSafeString(9),
                    Phone = sqlDataReader.GetSafeString(10),
                    PasswordHash = sqlDataReader.GetSafeString(11),
                    PasswordSalt = sqlDataReader.GetSafeString(12),
                    rowguid = sqlDataReader.GetGuid(13),
                    ModifiedDate = sqlDataReader.GetDateTime(14)
                });
            }

            // Return the list of customers
            return customers;
        }

        /// <summary>
        /// Quick extension method to get a string from a reader
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="colIndex"></param>
        /// <returns></returns>
        public static string GetSafeString(this SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return string.Empty;
        }
    }

}
