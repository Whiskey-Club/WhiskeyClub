namespace WhiskeyClub.Website.FrontEnd.Models.Reviews;

/// <summary>
/// Defines an interface for a repository that holds review aggregates.
/// </summary>
public interface IReviewRepository
{
    /// <summary>
    /// Asynchronously gets all the reviews in the repository.
    /// </summary>
    /// <param name="token">The cancellation token.</param>
    /// <returns>The collection of reviews in the repository.</returns>
    Task<IEnumerable<Review>> GetAllReviewsAsync(CancellationToken token);

    /// <summary>
    /// Asynchronously gets a review with the specified identifier.
    /// </summary>
    /// <param name="reviewId">The review identifier.</param>
    /// <param name="token">The cancellation token.</param>
    /// <returns>The review, or null if none was found.</returns>
    Task<Review> GetReviewAsync(string reviewId, CancellationToken token);

    /// <summary>
    /// Asynchronously adds a review to the repository.
    /// </summary>
    /// <param name="review">The review to add.</param>
    /// <param name="token">The cancellation token.</param>
    /// <returns>True if the item was added, false otherwise.</returns>
    Task<bool> AddReviewAsync(Review review, CancellationToken token);
}
