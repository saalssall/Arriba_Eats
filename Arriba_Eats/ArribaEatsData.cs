namespace Assignment_2B;
/// <summary>
/// A class to handle the lists of all users, restaurants, emails, and orders
/// </summary>
public class ArribaEatsData
{
    // Creating a list to store the user's information
    private List<User> users = new();

    public List<User> usersList
    {
        get { return users;}
    }

    public void AddUser(User user) // A method to add user to the list
    {
        users.Add(user);
    }
    
    // Creating a list of restaurants
    private List<Restaurant> restaurants = new();

    public List<Restaurant> restaurantsList
    {
        get { return restaurants;}
    }

    public void AddRestaurant(Restaurant restaurant) // A method to add restaurant to the restaurant list
    {
        restaurants.Add(restaurant);
    }
    // A list to store all orders
    public List<Order> AllOrders = new();

    public void AddOrder(Order order) // A method to add orders to the list of orders
    {
        AllOrders.Add(order);
    }
    
    // A list to store the emails of users
    public List<string> emailList = new ();
    
    private List<string> emails
    {
        get { return emailList;}
    }

    public void AddEmail(String email)
    {
        emails.Add(email);
    }
}