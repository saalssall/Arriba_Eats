namespace Assignment_2B;

/// <summary>
/// A class for displaying the deliverer menu and handling their interactions.
/// </summary>
public class DelivererMenu
{
    private ArribaEatsData arribaEatsData;
    private UserManager userManager;

    public DelivererMenu(ArribaEatsData arribaEatsData, UserManager userManager)
    {
        this.arribaEatsData = arribaEatsData;
        this.userManager = userManager;
    }
     /// <summary>
    /// A method to register the deliverer with his information.
    /// </summary>
    /// <param name="deliverer">The deliverer who delivers the food.</param>
    public void RegisterDelivererMenu(Deliverer deliverer)
    {
        bool loggedIn = true;
        while (loggedIn)
        {
            const string ADMINMENU_STR = "Please make a choice from the menu below:"; // Heading
            const string INFO_STR = "Display your user information"; // Option 1
            const string LIST_STR = "List orders available to deliver"; // Option 2
            const string ARRIVED_STR = "Arrived at restaurant to pick up order"; // Option 3
            const string COMPLETE_STR = "Mark this delivery as complete";
            const string LOGOUT_STR = "Log out";
            const int DPLAY_INFO = 0, LIST_ORDERS = 1, ARRIVED_RESTUARANT = 2, COMPLETE_ORDER = 3, LOGOUT = 4;
            int option = CmdLineUI.GetOption(ADMINMENU_STR, INFO_STR, LIST_STR, ARRIVED_STR, COMPLETE_STR, LOGOUT_STR);
   
            switch (option)
            {
                case DPLAY_INFO:
                    deliverer.GetUserInfo();
                    break;
                case LIST_ORDERS:
                    ListOrders(deliverer);
                    break;
                case ARRIVED_RESTUARANT:
                    ArrivedRestaurant(deliverer);
                    break;
                case COMPLETE_ORDER:
                   CompleteDelivery(deliverer);
                    break;
                case LOGOUT:
                    CmdLineUI.DisplayMessage("You are now logged out.");
                    loggedIn = false;
                    break;
                default:
                    CmdLineUI.DisplayMessage("Wrong main menu choice");
                    break;
            }
        }
    }
     
    /// <summary>
    /// A method for the deliverer to list orders.
    /// </summary>
    /// <param name="deliverer">The deliverer who delivers the food.</param>
   private void ListOrders(Deliverer deliverer)
    {
    // Ask and validate deliverer's location
    Location delivererLocation = null;
    while (delivererLocation == null)
    {
        CmdLineUI.DisplayMessage("Please enter your location (in the form of X,Y):");
        delivererLocation = CmdLineUI.GetLocation();
   
        if (delivererLocation == null)
        {
            CmdLineUI.DisplayMessage("Invalid location.");
        }
    }
    // Get all unassigned orders that have been ordered
    var availableOrders = arribaEatsData.AllOrders
        .Where(o => o.OrderStatus == OrderStatus.Ordered && o.deliverer == null)
        .OrderBy(o => o.OrderID).ToList(); //Sort them based on Order ID
    if (availableOrders.Count == 0)
    {
        CmdLineUI.DisplayMessage("No orders available for delivery at the moment.");
        return;
    }
    // Display list header
    CmdLineUI.DisplayMessage("The following orders are available for delivery. Select an order to accept it:");
    CmdLineUI.DisplayMessage("Order  Restaurant Name       Loc     Customer Name     Loc     Dist");
    //  Show available orders with calculated taxicab distance
    for (int i = 0; i < availableOrders.Count; i++)
    {
        var order = availableOrders[i]; var restaurant = order.Restaurant; var customer = order.Customer;
        //Calculate the distance between the restaurant and the deliverer
        double distToRestaurant = delivererLocation.CalculateDistance(restaurant.Location);
        double distToCustomer = restaurant.Location.CalculateDistance(customer.Location);
        double totalDistance = distToRestaurant + distToCustomer;
        CmdLineUI.DisplayMessage(
            $"{i+1}: {order.OrderID}  {restaurant.RestaurantName}  " +
            $"        {restaurant.Location.X},{restaurant.Location.Y}   " +
            $"      {customer.Name}"+           $"   {customer.Location.X},{customer.Location.Y} " +
            $"{totalDistance:0}");
    }
    //  Return option
    int returnOption = availableOrders.Count + 1;
    CmdLineUI.DisplayMessage($"{returnOption}: Return to the previous menu");
    //  Let user pick an order (if you want to handle input here)
    CmdLineUI.DisplayMessage($"Please enter a choice between 1 and {returnOption}:");
    int choice = CmdLineUI.GetIntInRange(1, returnOption);
    if (choice == returnOption)
        return;
    // Assign selected order to deliverer
    var selectedOrder = availableOrders[choice- 1];
    selectedOrder.deliverer = deliverer;
    deliverer.order = selectedOrder;
    
    CmdLineUI.DisplayMessage($"Thanks for accepting the order. Please head to {selectedOrder.Restaurant.RestaurantName} at " +
                             $"{selectedOrder.Restaurant.Location.X},{selectedOrder.Restaurant.Location.Y} to pick it up."); 
    }
   
   /// <summary>
   /// A method to show the deliverer has arrived at the restaurant.
   /// </summary>
   /// <param name="deliverer">The deliverer who picks up the food.</param>
    private void ArrivedRestaurant(Deliverer deliverer)
    {
        //Create a new order object for deliverer
        Order currentOrder = deliverer.order;
   
        CmdLineUI.DisplayMessage($"Thanks. We have informed {currentOrder.Restaurant.RestaurantName} that you have arrived" +
                                 $"and are ready to pick up order #{currentOrder.OrderID}.");
        CmdLineUI.DisplayMessage("Please show the staff this screen as confirmation.");
        CmdLineUI.DisplayMessage($"When you have the order, please deliver it to {currentOrder.Customer.Name} at " +
                                 $"{currentOrder.Customer.Location.X},{currentOrder.Customer.Location.Y}.");
        
    }
    
    /// <summary>
    /// A method for the deliverer to complete the order
    /// </summary>
    /// <param name="deliverer">The deliverer who delivered the food.</param>
    private void CompleteDelivery(Deliverer deliverer)
    {
        if (deliverer.order == null) // If there are no orders
        {
                CmdLineUI.DisplayMessage("You do not have an active order to deliver.");
                return;
        }
        
        Order currentOrder = deliverer.order; //assign the deliverer an order and store it in currentOrder
        // Mark as delivered
        currentOrder.OrderStatus = OrderStatus.Delivered; //Change the order status to delivered
        deliverer.order = null; // The deliverer does not have an order anymore
        CmdLineUI.DisplayMessage("Thank you for making the delivery."); 
    }
    
}
