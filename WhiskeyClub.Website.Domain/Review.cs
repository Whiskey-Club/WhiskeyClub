using Newtonsoft.Json;

namespace WhiskeyClub.Website.Domain;

/// <summary>
/// Defines a review aggregate.
/// </summary>
public class Review
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Review" /> class.
    /// </summary>
    /// <param name="id">The review identifier.</param>
    /// <param name="spirit">The spirit information.</param>
    public Review(string id, SpiritInfo spirit)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException($"'{nameof(id)}' cannot be null or whitespace.", nameof(id));
        }

        this.Id = id;
        this.Spirit = spirit ?? throw new ArgumentNullException(nameof(spirit));
    }

    /// <summary>
    /// Gets the review identifier.
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; }

    /// <summary>
    /// Gets the spirit information.
    /// </summary>
    [JsonProperty("spirit")]
    public SpiritInfo Spirit { get; }

    /// <summary>
    /// Gets the rating, out of 5.
    /// </summary>
    [JsonProperty("rating")]
    public int Rating { get; private set; } 

    /// <summary>
    /// Gets the notes for the review.
    /// </summary>
    [JsonProperty("notes")]
    public string Notes { get; private set; } = string.Empty;

    /// <summary>
    /// Rates the spirit in the review.
    /// </summary>
    /// <param name="rating">The rating, out of 5.</param>
    public void Rate(int rating)
    {
        this.Rating = rating;
    }

    /// <summary>
    /// Sets the notes for the spirit in the view.
    /// </summary>
    /// <param name="notes">The notes.</param>
    public void Note(string notes)
    {
        this.Notes = notes;
    }
}