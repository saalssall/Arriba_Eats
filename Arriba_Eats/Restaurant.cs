namespace Assignment_2B;
    /// <summary>
    /// A class to manage the restaurant 
    /// </summary>
public class Restaurant
{
    // Declaring fields and properties 

    private Location location;

    public Location Location
    {
        get;
    }
    
    private string restaurantName;
    public string RestaurantName
    {
        get;
    }
   
    private string restaurantStyle;
    public  string RestaurantStyle
    {
        get;
    }
    
    private double restaurantRating;
    public double Rating
    {
        get;
    }
    
    // A list of ratings
    private List<Rating> ratings = new ();

    public void AddRating(Rating rating) // Add ratings to the list
    {
        ratings.Add(rating);
    }
    // Get the average rating for restaurants
    public double AverageRating
    {
        get
        {
            return ratings.Count > 0 ? ratings.Average(r => r.Score) : -1; // calculate valid average rating scores
        }
    }
    // A method for calculating all ratings
    public List<Rating> GetAllRatings()
    {
        return ratings;
    }
    
    // A list for storing restaurant items
    public List<Item> RestaurantItems = new ();
    /// <summary>
    /// A constructor for the restaurant class
    /// </summary>
    /// <param name="restaurantName"></param>
    /// <param name="restaurantStyle"></param>
    /// <param name="rating"></param>
    
    public Restaurant(string restaurantName, Location location, string restaurantStyle, double rating)
    {
        RestaurantName = restaurantName;
        Location = location;
        RestaurantStyle = restaurantStyle;
        Rating = rating;
    }
}

   