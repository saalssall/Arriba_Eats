namespace Assignment_2B;
/// <summary>
/// A class for displaying the customer menu and handling their interactions.
/// </summary>
public class CustomerMenu
{
    private  ArribaEatsData arribaEatsData;
    private  UserManager userManager;

    public CustomerMenu(ArribaEatsData arribaEatsData, UserManager userManager)
    {
        this.arribaEatsData = arribaEatsData;
        this.userManager = userManager;
    }

    /// <summary>
    /// A menu for managing the customer.
    /// </summary>
    /// <param name="customer">A menu for customer interactions.</param>
    public void RegisterCustomerMenu(Customer customer)
    { 
        bool loggedIn = true;
        while (loggedIn)
        {
            CmdLineUI.DisplayMessage();
            const string ADMINMENU_STR = "Please make a choice from the menu below:";
            const string INFO_STR = "Display your user information";
            const string LIST_STR = "Select a list of restaurants to order from";
            const string STATUS_STR = "See the status of your orders";
            const string RATE_STR = "Rate a restaurant you've ordered from";
            const string LOGOUT_STR = "Log out";
            const int DPLAY_INFO = 0, LIST_RESTUARANTS = 1, SEE_STATUS = 2, RATE_RESTUARANT = 3, LOGOUT = 4;
            int option = CmdLineUI.GetOption(ADMINMENU_STR, INFO_STR, LIST_STR, STATUS_STR, RATE_STR, LOGOUT_STR);
   
            switch (option)
            {
                case DPLAY_INFO:
                    customer.GetUserInfo();
                    break;
                case LIST_RESTUARANTS:
                    SortOrderMenu(customer);
                    break;
                case SEE_STATUS:
                    CheckOrderStatus(customer);
                    break;
                case RATE_RESTUARANT: 
                    RateOrder(customer);
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
    /// A method for the customer to sort the orders
    /// </summary>
    /// <param name="currentCustomer">A method for the customer to sort orders.</param>
    private void SortOrderMenu(Customer currentCustomer)
    {
        CmdLineUI.DisplayMessage();
        const string ADMINMENU_STR = "How would you like the list of restaurants ordered?";
        const string NAME_STR = "Sorted alphabetically by name";
        const string DISTANCE_STR = "Sorted by distance";
        const string STYLE_STR = "Sorted by style";
        const string RATING_STR = "Sorted by average rating";
        const string RETURN_STR = "Return to the previous menu";
        const int SORT_NAME_INT = 0, DISTANCE_INT = 1, STYLE_INT = 2, RATING_INT = 3, RETURN_INT = 4;
        int option = CmdLineUI.GetOption(ADMINMENU_STR, NAME_STR, DISTANCE_STR, STYLE_STR, RATING_STR,  RETURN_STR);
   
        switch (option)
        {
            case SORT_NAME_INT:
                SortRestaurantsByName(currentCustomer);
                break;
            case DISTANCE_INT:
                SortRestaurantsByDistance(currentCustomer);
                break;
            case STYLE_INT:
                SortRestaurantsByStyle(currentCustomer);
                break;
            case RATING_INT:
                SortRestaurantsByRating(currentCustomer);
                break;
            case RETURN_INT:
                break;
            default:
                CmdLineUI.DisplayMessage("Wrong main menu choice");
                break;
        }
    }
    
   /// <summary>
   /// A method to sort the orders alphabetically based on name
   /// </summary>
   /// <param name="currentCustomer">The customer who wants to sort restaurants by name.</param>
    private void SortRestaurantsByName(Customer currentCustomer)
    {
        var sortedRestaurants = arribaEatsData.restaurantsList //Sort restaurants based on their names and change the result back to a list
            .OrderBy(r => r.RestaurantName)
            .ToList();
        CmdLineUI.DisplayMessage("You can order from the following restaurants:");
        CmdLineUI.DisplayMessage("  Restaurant Name    Loc     Dist     Style     Rating");
        int count = 1;
        foreach (var r in sortedRestaurants)
        {
            string name = r.RestaurantName;
            string loc = $"{r.Location.X},{r.Location.Y}";
            //Calculate the distance between the customer and the restaurant
            double distance = r.Location.CalculateDistance(currentCustomer.Location); 
            string style = r.RestaurantStyle;
            //Show a "-" if the rating is not valid, otherwise format the string accordingly (one decimal place)
            string rating = r.AverageRating >= 0 ? r.AverageRating.ToString("0.0") : "-";
            //Use pad right method for distance
            CmdLineUI.DisplayMessage($"{count}: " +
                                     $"{name.PadRight(10)}     " +
                                     $"{loc.PadRight(10)}   " +
                                     $"{distance}    " +
                                     $"{style.PadRight(10)}  " +
                                     $"{rating.PadRight(10)}");
            count++;
        }
        CmdLineUI.DisplayMessage($"{count}: Return to the previous menu");
        CmdLineUI.DisplayMessage($"Please enter a choice between 1 and {count}:");
        int chosenSelected = CmdLineUI.GetIntInRange(1, count); // only accept integer values between 1 and count
        if (chosenSelected == count)
        {
            return;
        }
        // Assign the restaurant chosen by user to currentRestaurant
        Restaurant currentRestaurant = sortedRestaurants[chosenSelected - 1]; 
        CmdLineUI.DisplayMessage($"Placing order from {currentRestaurant.RestaurantName}.");
        bool stayInMenu = true;
        while (stayInMenu)
        {
            const string EMPTY_STR = "";
            const string SEE_STR = "See this restaurant's menu and place an order";
            const string REVIEWS_STR = "See reviews for this restaurant";
            const string RETURN_STR = "Return to main menu";
            const int SEE_INT = 0, REVIEWS_INT = 1, RETURN_INT = 2;
            int option = CmdLineUI.GetOption(EMPTY_STR, SEE_STR, REVIEWS_STR, RETURN_STR);
            switch (option)
            {
                case SEE_INT:
                    PlaceOrder(currentRestaurant, currentCustomer);
                    break;
                case REVIEWS_INT:
                    DisplayRestaurantReviews(currentRestaurant);
                    break;
                case RETURN_INT:
                    stayInMenu = false;
                    break;
                default:
                    CmdLineUI.DisplayMessage("Wrong main menu choice");
                    break;
            }
        }
    }
    /// <summary>
    /// A method for the customer to check the status of his order.
    /// </summary>
    /// <param name="currentCustomer">A method for the logged in customer to check the status of their orders</param>
    private void CheckOrderStatus(Customer currentCustomer)
    {
        if (currentCustomer == null || currentCustomer.orders.Count == 0) //if there is no customer or order
        {
            CmdLineUI.DisplayMessage("You have not placed any orders.");
            return;
        }
        // Display all orders with their status and items sorting based on OrderID
        foreach (Order order in currentCustomer.orders.OrderBy(o => o.OrderID))
        {
            CmdLineUI.DisplayMessage(
                $"Order #{order.OrderID} from {order.Restaurant.RestaurantName}: {order.OrderStatus}");
            
            if (order.deliverer != null) //If a deliverer is assigned, then display the below message
            {
                CmdLineUI.DisplayMessage(
                    $"This order was delivered by {order.deliverer.Name} " +
                    $"(licence plate: {order.deliverer.LicencePlate})");
            }
            foreach (Item item in order.Items)
            {
                CmdLineUI.DisplayMessage($"{item.ItemQuantity} x {item.ItemName}");
            }
        }
    }
    
     /// <summary>
    /// A method for the customer to rate the order
    /// </summary>
    /// <param name="customer">The customer who wants to rate the order.</param>
    private void RateOrder(Customer customer)
    {
        CmdLineUI.DisplayMessage("Select a previous order to rate the restaurant it came from:");
        var customerOrders = arribaEatsData.AllOrders //Sort a list of orders for a specific customer based on their order ID
            .Where(order => order.Customer == customer)  
            .OrderBy(order => order.OrderID)
            .ToList();
        int count = 1;
        if (customerOrders.Count == 0)
        {
            CmdLineUI.DisplayMessage($"{count}: Return to the previous menu");
            CmdLineUI.DisplayMessage($"Please enter a choice between {count} and {count}:");
            int choice = CmdLineUI.GetIntInRange(1, 1); 
            if (choice == 1) return;
        }
       
        if (customerOrders.Count > 0)
        {
            foreach (var order in customerOrders)
            {
                CmdLineUI.DisplayMessage($"{count}: Order #{order.OrderID} from {order.Restaurant.RestaurantName}");
                count++;
            }
        }
        CmdLineUI.DisplayMessage($"{count}: Return to the previous menu");
        CmdLineUI.DisplayMessage($"Please enter a choice between 1 and {count}:");
        // Get user choice
        int chosenOption = CmdLineUI.GetIntInRange(1, count);
    
        if (chosenOption == count)
        {
            return; 
        }
        // Assign the order selected by customer to the selectedOrder
        Order selectedOrder = customerOrders[chosenOption - 1];
        CmdLineUI.DisplayMessage($"You are rating order #{selectedOrder.OrderID} from {selectedOrder.Restaurant.RestaurantName}:");
        foreach (var item in selectedOrder.Items)
        {
            CmdLineUI.DisplayMessage($"{item.ItemQuantity} x {item.ItemName}");
        }
        HandleOrdersCustomers(selectedOrder); // A method to hand the selected order
    }
    
    /// <summary>
    /// A method for the customer rating.
    /// </summary>
    /// <param name="order">The order that is being rated by customer.</param>
    private void HandleOrdersCustomers(Order order)
    {
        CmdLineUI.DisplayMessage("Please enter a rating for this restaurant (1-5, 0 to cancel):");
        int rating = CmdLineUI.GetIntInRange(0, 5);
        if (rating == 0)
        {
            return;
        }
        CmdLineUI.DisplayMessage("Please enter a comment to accompany this rating:");
        string comment = CmdLineUI.GetString();
        Rating newRating = new Rating(rating, comment, order.Customer); //Create a new rating 
        order.Restaurant.AddRating(newRating); //Add the rating to the restaurant associated with the order
        CmdLineUI.DisplayMessage($"Thank you for rating {order.Restaurant.RestaurantName}.");
    } 
       /// <summary>
    /// A method to show the reviews of the customer for the current restaurant.
    /// </summary>
    /// <param name="restaurant">The restaurant from which an order has been placed.</param>
    private void DisplayRestaurantReviews(Restaurant restaurant)
    {
        var reviews = restaurant.GetAllRatings(); //Call the method on the restaurant object
        if (reviews == null || reviews.Count == 0)
        {
            CmdLineUI.DisplayMessage("No reviews yet.");
            return;
        }
        foreach (var r in reviews)
        {
            CmdLineUI.DisplayMessage($"Reviewer: {r.RatedBy.Name}" +
                                     $"\nRating: {new string('*', r.Score)}" +
                                     $"\nComment: {r.Comment}\n");
        }
    }
            
    /// <summary>
    /// A method to display the restaurant menu for the customer. 
    /// </summary>
    /// <param name="restaurant">The restaurant the order has been placed from.</param>
    /// <param name="currentOrder">The current order placed by the customer.</param>
    private void DisplayRestaurantMenu(Restaurant restaurant, List<Item> currentOrder)
    {
        double total = currentOrder.Sum(item => item.ItemPrice * item.ItemQuantity); //Calculate the orders' total price
        CmdLineUI.DisplayMessage($"Current order total: {total:C2}");
   
        for (int i = 0; i < restaurant.RestaurantItems.Count; i++) //Display each item in the list starting from index 1
        {
            var item = restaurant.RestaurantItems[i];
            CmdLineUI.DisplayMessage($"{i + 1}:   {item.ItemPrice:C2}  {item.ItemName}");
        }
        int completeOption = restaurant.RestaurantItems.Count + 1; // option for completing the order
        int cancelOption = completeOption + 1;
        CmdLineUI.DisplayMessage($"{completeOption}: Complete order");
        CmdLineUI.DisplayMessage($"{cancelOption}: Cancel order");
    }
    
    /// <summary>
    /// A method for the customer to place order from the restaurant 
    /// </summary>
    /// <param name="currentRestaurant">The restaurant the oder is being placed from.</param>
    /// <param name="currentCustomer">The customer who places an order.</param>
    private void PlaceOrder(Restaurant currentRestaurant, Customer currentCustomer)
    {
        List<Item> orderItems = new List<Item>(); // A list of items
        bool ordering = true;
        while (ordering)
        {
            DisplayRestaurantMenu(currentRestaurant, orderItems); // A method for display the restaurant menu
            int completeOption = currentRestaurant.RestaurantItems.Count + 1;
            int cancelOption = completeOption + 1;
            CmdLineUI.DisplayMessage($"Please enter a choice between 1 and {cancelOption}:");
            int choice = CmdLineUI.GetInt();
            if (choice >= 1 && choice <= currentRestaurant.RestaurantItems.Count) //Check for valid item selection 
            {
                //Assign item object and adjust the user option to 0-indexing
                Item selectedItem = currentRestaurant.RestaurantItems[choice - 1]; 
                CmdLineUI.DisplayMessage($"Adding {selectedItem.ItemName} to order.");
                CmdLineUI.DisplayMessage("Please enter quantity (0 to cancel):");
                int quantity = CmdLineUI.GetInt();
                if (quantity > 0)
                {
                    //Check if an item already exists and if it does, assign it to existingItem 
                    Item existingItem = orderItems.FirstOrDefault(i => i.ItemName == selectedItem.ItemName);
                    
                    if (existingItem != null) 
                    {
                        existingItem.ItemQuantity += quantity; //Increase the quantity of the item
                                                               //by quantity entered by user
                        CmdLineUI.DisplayMessage($"Added {quantity} x {existingItem.ItemName} to order.");
                    }
                    else
                    {
                        //Create a new item and assign quantity 
                        Item orderItem = new Item(selectedItem.ItemName, selectedItem.ItemPrice)
                        {
                            ItemQuantity = quantity
                        };
                        orderItems.Add(orderItem);
                        CmdLineUI.DisplayMessage($"Added {orderItem.ItemQuantity} x {orderItem.ItemName} to order.");
                    }
                }
            }
            else if (choice == completeOption)
            {
                ordering = false;
                Order newOrder = new Order(orderItems, currentRestaurant, currentCustomer); //Make a new order object
                //AllOrders.Add(newOrder); //Add the new order to the list of all orders
                arribaEatsData.AddOrder(newOrder);
                currentCustomer.orders.Add(newOrder); //Add the order to the order list in current customer 
                CmdLineUI.DisplayMessage($"Your order has been placed. Your order number is #{newOrder.OrderID}.");
            }
            else if (choice == cancelOption)
            {
                ordering = false; 
                CmdLineUI.DisplayMessage();
            }
        }
    }
       /// <summary>
   /// A method for the customer to sort orders based on rating.
   /// </summary>
   /// <param name="currentCustomer">The customer who wants to sort orders.</param>
    private void SortRestaurantsByRating(Customer currentCustomer)
    {
        var sortedRestaurantsByRating = arribaEatsData.restaurantsList
            .OrderBy(r => r.Rating) //Sort the restaurants by rating
            .ToList();
        CmdLineUI.DisplayMessage("You can order from the following restaurants:");
        CmdLineUI.DisplayMessage(" Restaurant Name    Loc     Dist     Style     Rating");
        int count = 1;
        foreach (var r in sortedRestaurantsByRating)
        {
            string name  = r.RestaurantName;
            string loc = $"{r.Location.X},{r.Location.Y}";
            double distance = r.Location.CalculateDistance(currentCustomer.Location);
            string style = r.RestaurantStyle;
            string rating = r.Rating.ToString("-");
            CmdLineUI.DisplayMessage($"{count}:   {name.PadRight(10)}     {loc.PadRight(15)}   {distance}    {style.PadRight(10)}     {rating}");
            count++;
        }
        CmdLineUI.DisplayMessage($"{count}: Return to the previous menu");
        CmdLineUI.DisplayMessage($"Please enter a choice between 1 and {count}:");
        int choice = CmdLineUI.GetInt();
        if (choice == count)
        {
            return;
        }
    }
    
    /// <summary>
    /// A method for the customer to sort the restuarants by distance 
    /// </summary>
    /// <param name="currentCustomer">The customer who wants to sort orders based on distance.</param>
    private void SortRestaurantsByDistance(Customer currentCustomer)
    {
        var sortedRestaurantsDistance = arribaEatsData.restaurantsList
            .OrderBy(r => r.Location.CalculateDistance(currentCustomer.Location)) //Calculate the distance between the
                                                                                  //customer and the restaurant 
            .ThenBy(r => r.RestaurantName)                                        
            .ToList();
        CmdLineUI.DisplayMessage("You can order from the following restaurants:");
        CmdLineUI.DisplayMessage(" Restaurant Name    Loc     Dist     Style     Rating");
        int count = 1;
        foreach (var r in sortedRestaurantsDistance)
        {
            string name  = r.RestaurantName;
            string loc = $"{r.Location.X},{r.Location.Y}";
            double distance = r.Location.CalculateDistance(currentCustomer.Location);
            string style = r.RestaurantStyle;
            string rating = r.Rating.ToString("-");
            CmdLineUI.DisplayMessage($"{count}:   {name.PadRight(10)}     {loc.PadRight(15)}   {distance}    {style.PadRight(10)}     {rating}");
            count++;
        }
        CmdLineUI.DisplayMessage($"{count}: Return to the previous menu");
        CmdLineUI.DisplayMessage($"Please enter a choice between 1 and {count}:");
        int choice = CmdLineUI.GetInt();
        if (choice == count)
        {
            return;
        }
    }
    
    /// <summary>
    /// A method for the customer to sort the restaurants by style
    /// </summary>
    /// <param name="currentCustomer">The customer who wants to sort orders based on style.</param>
    private void SortRestaurantsByStyle(Customer currentCustomer)
    {
        List<string> styleOrder = new List<string> // A list for different styles
        {
            "Italian", "French", "Chinese", "Japanese", "American", "Australian"
        };
        var sortedRestaurantsStyle = arribaEatsData.restaurantsList //Sort the restaurant first by style then by name
            .OrderBy(r => styleOrder.IndexOf(r.RestaurantStyle))
            .ThenBy(r => r.RestaurantName)
            .ToList();
        CmdLineUI.DisplayMessage("You can order from the following restaurants:");
        CmdLineUI.DisplayMessage(" Restaurant Name    Loc     Dist     Style     Rating");
        int count = 1;
        foreach (var r in sortedRestaurantsStyle)
        {
            string name  = r.RestaurantName;
            string loc = $"{r.Location.X},{r.Location.Y}";
            double distance = r.Location.CalculateDistance(currentCustomer.Location);
            string style = r.RestaurantStyle;
            string rating = r.Rating.ToString("-");
            CmdLineUI.DisplayMessage($"{count}:   {name.PadRight(10)}     {loc.PadRight(15)}   {distance}    {style.PadRight(10)}     {rating}");
            count++;
        }
        CmdLineUI.DisplayMessage($"{count}: Return to the previous menu");
        CmdLineUI.DisplayMessage($"Please enter a choice between 1 and {count}:");
        int choice = CmdLineUI.GetInt();
        if (choice == count) 
        {
            return;
        }
    }
}

