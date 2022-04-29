namespace WhiskeyClub.Website.FrontEnd.Models.Spirits;

public class Spirit
{
    public Spirit(string id)
    {
        this.Id = id;
    }

    /// <summary>
    /// Gets the spirit identifier.
    /// </summary>
    public string Id { get; }

    public string Name {get;set;}
    public string Brand {get;set;}
}