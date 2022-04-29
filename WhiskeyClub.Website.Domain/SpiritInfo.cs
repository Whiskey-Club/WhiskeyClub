using Newtonsoft.Json;

namespace WhiskeyClub.Website.Domain;

/// <summary>
/// Defines a value object that contains spirit info for use in the <see cref="Review" /> aggregate.
/// </summary>
public class SpiritInfo
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SpiritInfo" /> class.
    /// </summary>
    /// <param name="spiritId">The spirit identifier.</param>
    /// <param name="spiritName">The spirit name.</param>
    /// <param name="spiritBrand">The spirit brand.</param>
    public SpiritInfo(string spiritId, string spiritName, string spiritBrand)
    {
        if (string.IsNullOrWhiteSpace(spiritId))
        {
            throw new ArgumentException($"'{nameof(spiritId)}' cannot be null or whitespace.", nameof(spiritId));
        }

        if (string.IsNullOrWhiteSpace(spiritName))
        {
            throw new ArgumentException($"'{nameof(spiritName)}' cannot be null or whitespace.", nameof(spiritName));
        }

        if (string.IsNullOrWhiteSpace(spiritBrand))
        {
            throw new ArgumentException($"'{nameof(spiritBrand)}' cannot be null or whitespace.", nameof(spiritBrand));
        }

        this.SpiritId = spiritId;
        this.SpiritName = spiritName;
        this.SpiritBrand = spiritBrand;
    }

    /// <summary>
    /// Gets the spirit identifier.
    /// </summary>
    [JsonProperty("spiritId")]
    public string SpiritId { get; }

    /// <summary>
    /// Gets the spirit name.
    /// </summary>
    [JsonProperty("spiritName")]
    public string SpiritName { get; }

    /// <summary>
    /// Gets the spirit brand.
    /// </summary>
    [JsonProperty("spiritBrand")]
    public string SpiritBrand { get; }
}
