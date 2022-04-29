using Newtonsoft.Json;

namespace WhiskeyClub.Website.FrontEnd.Reviews;

/// <summary>
/// Defines a value object that contains spirit info for use in the <see cref="Review" /> aggregate.
/// </summary>
public class SpiritInfo
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SpiritInfo" /> class.
    /// </summary>
    /// <param name="id">The spirit identifier.</param>
    /// <param name="name">The spirit name.</param>
    /// <param name="brand">The spirit brand.</param>
    public SpiritInfo(string id, string name, string brand)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException($"'{nameof(id)}' cannot be null or whitespace.", nameof(id));
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
        }

        if (string.IsNullOrWhiteSpace(brand))
        {
            throw new ArgumentException($"'{nameof(brand)}' cannot be null or whitespace.", nameof(brand));
        }

        this.Id = id;
        this.Name = name;
        this.Brand = brand;
    }

    /// <summary>
    /// Gets the spirit identifier.
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; }

    /// <summary>
    /// Gets the spirit name.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; }

    /// <summary>
    /// Gets the spirit brand.
    /// </summary>
    [JsonProperty("brand")]
    public string Brand { get; }
}
