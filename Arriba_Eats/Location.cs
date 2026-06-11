namespace Assignment_2B;
    /// <summary>
    /// A class to manage the location of the client, customers (and their restaurants)
    /// </summary>
public class Location
{
    //Declaring fields and properties for the location
    public int X { get;}
    public int Y { get;}
    /// <summary>
    /// A constructor for location
    /// </summary>
    /// <param name="x">X coordinate for the location</param>
    /// <param name="y">Y coordinate for the location</param>
    public Location(int x, int y)
    {
        X = x;
        Y = y;
    }
    /// <summary>
    /// A method for calculating the distance between two locations
    /// </summary>
    /// <param name="location">Calculating the distance between two locations</param>
    /// <returns></returns>
    public int CalculateDistance(Location location)
    {
        return Math.Abs(location.X - X) + Math.Abs(location.Y - Y);
    }
    
}
