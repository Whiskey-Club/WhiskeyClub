using System.Text;
using Newtonsoft.Json;

namespace WhiskeyClub.Website.FrontEnd.Models.Reviews;

/// <summary>
/// Provides an implementation of the <see cref="IReviewRepository"/> interface.
/// </summary>
public class ReviewRepository : IReviewRepository
{
    /// <inheritdoc />
    public async Task<IEnumerable<Review>> GetAllReviewsAsync(CancellationToken token)
    {
        try
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://whiskey-club.azurewebsites.net/api/reviews", token);
            return JsonConvert.DeserializeObject<IEnumerable<Review>>(await response.Content.ReadAsStringAsync(token));
        }
        catch
        {
            return Array.Empty<Review>();
        }
    }

    /// <inheritdoc />
    public async Task<Review> GetReviewAsync(string reviewId, CancellationToken token)
    {
        try
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"https://whiskey-club.azurewebsites.net/api/reviews/{reviewId}", token);
            return JsonConvert.DeserializeObject<Review>(await response.Content.ReadAsStringAsync(token));
        }
        catch (Exception)
        {
            return null!;
        }
    }

    /// <inheritdoc />
    public async Task<bool> AddReviewAsync(Review review, CancellationToken token)
    {
        try
        {
            var client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(review), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://whiskey-club.azurewebsites.net/api/reviews", content, token);
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }
        catch (Exception)
        {
            return false;
        }
    }
}