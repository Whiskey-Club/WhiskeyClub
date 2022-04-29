using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WhiskeyClub.Website.FrontEnd.Reviews;

/// <summary>
/// Defines a review aggregate.
/// </summary>
public class Review
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Review" /> class.
    /// </summary>
    /// <param name="id">The review identifier.</param>
    public Review(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException($"'{nameof(id)}' cannot be null or whitespace.", nameof(id));
        }

        this.Id = id;
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
    public SpiritInfo Spirit { get; private set; }

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
    /// Gets the author identifier.
    /// </summary>
    [JsonProperty("authorId")]
    public string AuthorId { get; private set; }

    /// <summary>
    /// Gets the author's name.
    /// </summary>
    /// <value></value>
    [JsonProperty("authorName")]
    public string AuthorName { get; private set; }

    /// <summary>
    /// Gets the date the review was created.
    /// </summary>
    [JsonProperty("created")]
    public DateTime Created { get; private set; }

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