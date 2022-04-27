namespace WhiskeyClub.Website.Domain
{

    /// <summary>
    /// A value object that represents a monthly drink selection.
    /// </summary>
    public class MonthlySelection
    {
        public MonthlySelection(SpiritEnum drinkCategory, string drinkMaker, int ageStatement = 0, double price) 
        {
            DrinkCategory = drinkCategory;
            DrinkMaker = drinkMaker;
            AgeStatement = ageStatement;
            Price = price;    
        }

        /// <summary>
        /// Gets the spirit enum.
        /// </summary>
        /// <value></value>
        public SpiritEnum DrinkCategory { get; } 

        /// <summary>
        /// Gets the company name that makes the spirit.
        /// </summary>
        public string DrinkMaker {get;}

        /// <summary>
        /// Gets the age statement of the spirit.
        /// </summary>
        public int AgeStatement {get; }

        /// <summary>
        /// Gets the price of the spirit.
        /// </summary>
        public double Price {get;}
    }
}