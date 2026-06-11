using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Runtime.InteropServices;

namespace Assignment_2B;
    /// <summary>
    /// A class for the customer type of user
    /// </summary>
public class Customer : User
{
    // Declaring fields and properties
    private Location location;
    public Location Location
    {
        get { return location; }
    }
    
    // A list to store the orders of customers
    public List<Order> orders = new ();
   
    /// <summary>
    /// Constructor for customer
    /// </summary>
    /// <param name="name">The name of the customer.</param>
    /// <param name="age">The age of the customer.</param>
    /// <param name="password">The password of the customer.</param>
    /// <param name="email">The email of the customer.</param>
    /// <param name="phoneNumber">The phone number of the customer.</param>
    /// <param name="location">The location of the customer.</param>
    /// <param name="userType">The type of the customer.</param>
    
    public Customer(string name, int age, string email,string phoneNumber, string password, Location location,
        string userType) :
        base(name, age, email, phoneNumber, password, userType)
    {
        this.location = location;
    }
   
    /// <summary>
    /// Displays the successful registration of user (customer)
    /// </summary>
    public override void DisplayMessageUser()
    {
        CmdLineUI.DisplayMessage($"You have been successfully registered as a {UserType}, {Name}!");
    }
    
    /// <summary>
    /// Displays the user details of user (customer) after completed registration
    /// </summary>
    public override void GetUserInfo()
    {
        CmdLineUI.DisplayMessage("Your user details are as follows:" +
                                 $"\nName: {Name}" + $"\nAge: {Age}"
                                 + $"\nEmail: {Email}" + $"\nMobile: {PhoneNumber}"
                                 + $"\nLocation: {location.X},{location.Y}");
        //If the order is null, count is zero. Otherwise, get the number of orders
        int totalOrders = orders?.Count ?? 0;
        double totalSpent = orders?.Sum(o => o.Items.Sum(i => i.ItemQuantity * i.ItemPrice)) ?? 0;

        CmdLineUI.DisplayMessage($"You've made {totalOrders} order(s) and spent a total of ${totalSpent:F2} here.");
    }
}