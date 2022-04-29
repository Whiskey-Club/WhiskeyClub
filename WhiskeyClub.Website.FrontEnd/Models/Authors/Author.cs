
using WhiskeyClub.Website.FrontEnd.Models.Spirits;
using WhiskeyClub.Website.FrontEnd.Reviews;

namespace WhiskeyClub.Website.FrontEnd;

public class Author
{
    public Author(string id)
    {
        this.Id = id;
    }

    /// <summary>
    /// Gets the author identifier.
    /// </summary>
    public string Id { get; }

    public string Name {get;set;}

    public Review CreateReview(Spirit spirit, int rating, string notes)
    {
        return new Review(Guid.NewGuid().ToString())
        {
            AuthorId = this.Id,
            AuthorName = this.Name,
            Created = DateTime.Now,
            Notes = notes,
            Rating = rating,
            Spirit = new SpiritInfo(spirit.Id, spirit.Name, spirit.Brand),            
        };
    }
}