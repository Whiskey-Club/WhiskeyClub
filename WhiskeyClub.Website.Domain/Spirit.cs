namespace WhiskeyClub.Website.Domain;

using System;
using Newtonsoft.Json;

public class Spirit
{    
    /// <summary>
    /// Gets or sets the spirit identifier.
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the spirit name.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the brand of the spirit.
    /// </summary>
    [JsonProperty("brand")]
    public string Brand { get; set; }

    /// <summary>
    /// Gets or sets the category.
    /// </summary>
    [JsonProperty("category")]
    public SpiritCategory Category { get; set; } 

    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    [JsonProperty("description")]
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the featured month.
    /// </summary>
    [JsonProperty("featuredMonth")]
    public DateTime? FeaturedMonth { get; set; }
}