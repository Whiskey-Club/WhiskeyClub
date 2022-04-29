using Newtonsoft.Json;

namespace WhiskeyClub.Website.FrontEnd.Reviews;

public class ReviewRepository
{
    public async Task<IEnumerable<Review>> GetAllReviewsAsync(CancellationToken token)
    {
        var client = new HttpClient();
        var response = await client.GetAsync("https://whiskey-club.azurewebsites.net/api/reviews", token);
        return JsonConvert.DeserializeObject<IEnumerable<Review>>(await response.Content.ReadAsStringAsync(token));
    }

    public async Task<Review> GetReviewAsync(string reviewId, CancellationToken token)
    {
        var client = new HttpClient();
        var response = await client.GetAsync($"https://whiskey-club.azurewebsites.net/api/reviews/{reviewId}", token);
        return JsonConvert.DeserializeObject<Review>(await response.Content.ReadAsStringAsync(token));
    }
}