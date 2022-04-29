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
