using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WhiskeyClub.Website.FrontEnd;

/// <summary>
/// Defines a model for the review component.
/// </summary>
public class ReviewComponentModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Review" /> class.
    /// </summary>
    /// <param name="id">The review identifier.</param>
    public ReviewComponentModel(string id)
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
    public string Id { get; }
    
    public string SpiritId { get; set; }
    public string SpiritName { get; set; }
    public string SpiritBrand { get; set; }

    /// <summary>
    /// Gets the rating, out of 5.
    /// </summary>
    public int Rating { get; set; } 

    /// <summary>
    /// Gets the notes for the review.
    /// </summary>
    public string Notes { get; set; } = string.Empty;

    /// <summary>
    /// Gets the author's name.
    /// </summary>
    [Required]
    [StringLength(100, ErrorMessage = "Author name is too long.")]
    public string AuthorName { get; set; }
}