using System.Text;
using Newtonsoft.Json;

namespace WhiskeyClub.Website.FrontEnd.Models.Spirits;
   
/// <summary>
/// Defines an interface for a repository that holds spirit aggregates.
/// </summary>
public interface ISpiritRepository
{
    /// <summary>
    /// Asynchronously gets all the spirits in the repository.
    /// </summary>
    /// <param name="token">The cancellation token.</param>
    /// <returns>The collection of spirits in the repository.</returns>
    Task<IEnumerable<Spirit>> GetAllSpiritsAsync(CancellationToken token);

    /// <summary>
    /// Asynchronously gets a spirit with the specified identifier.
    /// </summary>
    /// <param name="spiritId">The spirit identifier.</param>
    /// <param name="token">The cancellation token.</param>
    /// <returns>The spirit, or null if none was found.</returns>
    Task<Spirit> GetSpiritAsync(string spiritId, CancellationToken token);

    /// <summary>
    /// Asynchronously adds a spirit to the repository.
    /// </summary>
    /// <param name="spirit">The spirit to add.</param>
    /// <param name="token">The cancellation token.</param>
    /// <returns>True if the item was added, false otherwise.</returns>
    Task<bool> AddSpiritAsync(Spirit spirit, CancellationToken token);
}

/// <summary>
/// Provides an implementation of the <see cref="ISpiritRepository"/> interface.
/// </summary>
public class SpiritRepository : ISpiritRepository
{
    /// <inheritdoc />
    public async Task<IEnumerable<Spirit>> GetAllSpiritsAsync(CancellationToken token)
    {
        try
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://whiskey-club.azurewebsites.net/api/spirits", token);
            return JsonConvert.DeserializeObject<IEnumerable<Spirit>>(await response.Content.ReadAsStringAsync(token));
        }
        catch
        {
            return Array.Empty<Spirit>();
        }
    }

    /// <inheritdoc />
    public async Task<Spirit> GetSpiritAsync(string spiritId, CancellationToken token)
    {
        try
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"https://whiskey-club.azurewebsites.net/api/spirits/{spiritId}", token);
            return JsonConvert.DeserializeObject<Spirit>(await response.Content.ReadAsStringAsync(token));
        }
        catch (Exception)
        {
            return null!;
        }
    }

    /// <inheritdoc />
    public async Task<bool> AddSpiritAsync(Spirit spirit, CancellationToken token)
    {
        try
        {
            var client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(spirit), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://whiskey-club.azurewebsites.net/api/spirits", content, token);
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }
        catch (Exception)
        {
            return false;
        }
    }
}