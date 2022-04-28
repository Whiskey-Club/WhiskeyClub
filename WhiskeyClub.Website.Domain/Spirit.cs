namespace WhiskeyClub.Website.Domain;

using System;

public class Spirit
{    
    /// <summary>
    /// Gets or sets the spirit identifier.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the spirit name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the brand of the spirit.
    /// </summary>
    public string Brand { get; set; }

    /// <summary>
    /// Gets or sets the category.
    /// </summary>
    public SpiritCategory Category { get; set; } 

    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the featured month.
    /// </summary>
    public DateTime? FeaturedMonth { get; set; }
}