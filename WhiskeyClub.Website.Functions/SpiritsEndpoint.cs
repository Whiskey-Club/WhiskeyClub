using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WhiskeyClub.Website.Domain;
using System.Collections.Generic;
using System.Linq;

namespace WhiskeyClub.Website.Functions
{
    public static class SpiritsEndpoint
    {
        [FunctionName("CreateSpirit")]
        public static async Task<IActionResult> CreatSpiritAsync(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                "post",
                Route = "spirits")] HttpRequest request,
            [CosmosDB(
                databaseName: "WhiskeyClub",
                collectionName: "Spirits",
                ConnectionStringSetting = "COSMOS_DB_CONNECTION_STRING")] IAsyncCollector<Spirit> spiritsOut,
            ILogger log)
        {
            log.LogInformation("Post to /spirits");

            string requestBody = await new StreamReader(request.Body).ReadToEndAsync();
            Spirit spirit = JsonConvert.DeserializeObject<Spirit>(requestBody);

            await spiritsOut.AddAsync(spirit);
            // string responseMessage = string.IsNullOrEmpty(name)
            //     ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
            //     : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult("we good");
        }

        [FunctionName("GetSpirits")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get",
                Route = "spirits")]HttpRequest request,
            [CosmosDB(
                databaseName: "WhiskeyClub",
                collectionName: "Spirits",
                ConnectionStringSetting = "COSMOS_DB_CONNECTION_STRING")] IEnumerable<Spirit> spirits,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            if (!spirits.Any())
            {
                log.LogInformation($"No spirits found");
                return new NotFoundResult();
            }
            else
            {
                log.LogInformation($"Multiple spirits found: {spirits.Count()}");
                return new OkObjectResult(JsonConvert.SerializeObject(spirits));
            }
        }

        [FunctionName("GetSpirit")]
        public static IActionResult Run(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                "get",
                Route = "spirits/{id}")] HttpRequest request,
            [CosmosDB(
                databaseName: "WhiskeyClub",
                collectionName: "Spirits",
                ConnectionStringSetting = "COSMOS_DB_CONNECTION_STRING",
                Id = "{id}")] Spirit spirit,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            if (spirit == null)
            {
                log.LogInformation($"Spirit not found");
                return new NotFoundResult();
            }
            else
            {
                log.LogInformation($"Found spirit, Description={spirit.Name}");
                return new OkObjectResult(JsonConvert.SerializeObject(spirit));
            }
        }
    }
}
