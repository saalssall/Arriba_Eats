namespace Assignment_2B;

public class Deliverer: User
{
    // fields for deliverer
    private string licencePlate;
    public string LicencePlate
    {
        get { return licencePlate; }
    }
    public Order order;
    public Restaurant restaurant;
    /// <summary>
    /// A constructor for the deliverer
    /// </summary>
    /// <param name="name">The name of the deliverer.</param>
    /// <param name="age">The age of the deliverer.</param>
    /// <param name="password">The password of the deliverer.</param>
    /// <param name="email">The email of the deliverer.</param>
    /// <param name="phoneNumber">The phoneNumber of the deliverer.</param>
    /// <param name="licencePlate">The licencePlate of the deliverer.</param>
    /// <param name="userType">The type of the deliverer.</param>
    public  Deliverer(string name, int age, string email, string phoneNumber, string password, 
        string licencePlate, string userType) : 
        base(name, age, email, phoneNumber, password, userType)
    {
        this.licencePlate = licencePlate;
    }
    
    /// <summary>
    /// Displays the successful registration of user (deliverer)
    /// </summary>
    public override void DisplayMessageUser()
    {
        CmdLineUI.DisplayMessage($"You have been successfully registered as a {UserType}, {Name}!");
    } 
    /// <summary>
    /// Displays the user details of user (deliverer) after completed registration
    /// </summary>
    public override void GetUserInfo()
    {
        CmdLineUI.DisplayMessage("Your user details are as follows:" +
                                 $"\nName: {Name}" + $"\nAge: {Age}"
                                 + $"\nEmail: {Email}" + $"\nMobile: {PhoneNumber}"
                                 + $"\nLicence plate: {licencePlate}");
        if (order != null)
        {
            var restaurant = order.Restaurant;
            var customer = order.Customer;
            CmdLineUI.DisplayMessage($"\nCurrent delivery:" +
                                     $"\nOrder #{order.OrderID} from {restaurant.RestaurantName} at " +
                                     $"{restaurant.Location.X},{restaurant.Location.Y}."
                                     + $"\nTo be delivered to {customer.Name} at {customer.Location.X},{customer.Location.Y}.");
        }
    }
}