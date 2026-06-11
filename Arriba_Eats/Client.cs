namespace Assignment_2B;
    /// <summary>
    /// A class for client who is owner of the restaurant
    /// </summary>
public class Client : User
{
    
    // Declaring fields and properties 

    private Restaurant restaurant;
    public Restaurant Restaurant
    {
        get { return restaurant; }
    }
    
    private Location location;

    public Location Location
    {
        get { return location; }
    }

    /// <summary>
    /// The base constructor for client user.
    /// </summary>
    /// <param name="name">The name of the client.</param>
    /// <param name="age">The age of the client.</param>
    /// <param name="password">The password of the client.</param>
    /// <param name="email">The email of the client.</param>
    /// <param name="phoneNumber">The phoneNumber of the client.</param>
    /// <param name="location">The location of the client.</param>
    /// <param name="userType">The type of the client.</param>
    /// <param name="restaurant">The restaurant of the client.</param>
    public Client(string name, int age, string email,  string phoneNumber, string password, Location location, 
        string userType, Restaurant restaurant) :
        base(name, age, email, phoneNumber, password, userType)
    {
        this.location = location;
        this.restaurant = restaurant;
    }
    
    /// <summary>
    /// A method to display the successful registration of user (client)
    /// </summary>
    public override void DisplayMessageUser()
    {
        CmdLineUI.DisplayMessage($"You have been successfully registered as a {UserType}, {Name}!");
    } 
    /// <summary>
    /// A method to display the user details of user (client) after completed registration
    /// </summary>
    public override void GetUserInfo()
    {
        CmdLineUI.DisplayMessage("Your user details are as follows:" +
                                 $"\nName: {Name}" + $"\nAge: {Age}" 
                                 + $"\nEmail: {Email}" + $"\nMobile: {PhoneNumber}" 
                                 + $"\nRestaurant name: {Restaurant.RestaurantName}"
                                 + $"\nRestaurant style: {Restaurant.RestaurantStyle}"
                                 + $"\nRestaurant location: {location.X},{location.Y}");
    }
}