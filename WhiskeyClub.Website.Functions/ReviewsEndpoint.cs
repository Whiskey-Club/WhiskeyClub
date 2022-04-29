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
    /// <summary>
    /// Service that hosts the Azure Functions for the reviews/ endpoint.
    /// </summary>
    public static class ReviewsEndpoint
    {
        [FunctionName("GetAllReviews")]
        public static IActionResult GetAllReviews(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get",
                Route = "spirits")]HttpRequest request,
            [CosmosDB(
                databaseName: "WhiskeyClub",
                collectionName: "Reviews",
                SqlQuery = "select * from c",
                ConnectionStringSetting = "COSMOS_DB_CONNECTION_STRING")] IEnumerable<Review> reviews,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            if (!reviews.Any())
            {
                log.LogInformation($"No reviews found");
                return new NotFoundResult();
            }
            else
            {
                log.LogInformation($"Multiple spirits found: {reviews.Count()}");
                return new OkObjectResult(JsonConvert.SerializeObject(reviews));
            }
        }

        [FunctionName("CreateReview")]
        public static async Task<IActionResult> CreateReviewAsync(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                "post",
                Route = "reviews")] HttpRequest request,
            [CosmosDB(
                databaseName: "WhiskeyClub",
                collectionName: "Reviews",
                ConnectionStringSetting = "COSMOS_DB_CONNECTION_STRING")] IAsyncCollector<Review> reviews,
            ILogger log)
        {
            log.LogInformation("Received a create review request", request);

            string requestBody = await new StreamReader(request.Body).ReadToEndAsync();
            Review review = JsonConvert.DeserializeObject<Review>(requestBody);
            await reviews.AddAsync(review);
            return new OkResult();
        }
    }
}
