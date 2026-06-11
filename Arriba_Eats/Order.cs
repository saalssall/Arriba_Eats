namespace Assignment_2B;
    /// <summary>
    /// A class for the order 
    /// </summary>
public class Order
{
    public Customer Customer  { get; }
    private static int nextOrderID = 1; //Initial orderID
    public int OrderID { get; }
    public List<Item> Items { get; }  = new (); // A list of items
    public OrderStatus OrderStatus { get; set; }
    public Restaurant Restaurant { get; } 
    public Deliverer deliverer { get; set; } 
    
    /// <summary>
    /// A constructor for the order
    /// </summary>
    /// <param name="items">items the customer has ordered</param>
    /// <param name="restaurant">the restaurant the customer has ordered from</param>
    /// <param name="customer">the customer who has placed the order</param>
    public Order(List<Item> items, Restaurant restaurant, Customer customer)
    {
        OrderID = nextOrderID++; //Increment orderID by one
        Items = items;
        Restaurant = restaurant;
        Customer = customer;
        OrderStatus = OrderStatus.Ordered;
        deliverer = null;
    }
}