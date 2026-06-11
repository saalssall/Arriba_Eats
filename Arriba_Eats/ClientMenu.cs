namespace Assignment_2B;
/// <summary>
/// A class for displaying the client menu and handling their interactions.
/// </summary>
public class ClientMenu
{
    // Store references to data and user manager
    private ArribaEatsData arribaEatsData;
    private UserManager userManager;

    /// <summary>
    ///A constructor for the client menu to interact with data and registration/login 
    /// </summary>
    /// <param name="arribaEatsData">The data class that stores all the information.</param>
    /// <param name="userManager">The user manager class that handles login and registration.</param>
    public ClientMenu(ArribaEatsData arribaEatsData, UserManager userManager)
    {
        this.arribaEatsData = arribaEatsData;
        this.userManager = userManager;
    }

    /// <summary>
    /// A method to register the client with his information
    /// </summary>
    /// <param name="client">The restaurant owner (client)</param>
    public void RegisterClientMenu(Client client)
    {
        bool loggedIn = true;
        while (loggedIn)
        {
            const string ADMINMENU_STR = "Please make a choice from the menu below:"; // Heading
            const string INFO_STR = "Display your user information"; // Option 1
            const string ADD_STR = "Add item to restaurant menu"; // Option 2
            const string SEE_STR = "See current orders"; // Option 3
            const string START_STR = "Start cooking order"; // Option 4
            const string COMPLETE_STR = "Finish cooking order"; // Option 5
            const string HANDLE_DELIVERER_STR = "Handle deliverers who have arrived"; // Option 6
            const string LOGOUT_STR = "Log out";
            const int DPLAY_INFO = 0, ADD_ORDER = 1, SEE_ORDER = 2, START_ORDER = 3, COMPLETE_ORDER = 4, 
                HANDLE_DELIVERER = 5, LOGOUT = 6;
            int option = CmdLineUI.GetOption(ADMINMENU_STR, INFO_STR, ADD_STR, SEE_STR, START_STR,
                COMPLETE_STR, HANDLE_DELIVERER_STR, LOGOUT_STR);
            
            switch (option)
            {
                case DPLAY_INFO:
                    client.GetUserInfo();
                    break;
                case ADD_ORDER:
                    AddItem(client);
                    break;
                case SEE_ORDER:
                    SeeOrderClient(client);
                    break;
                case START_ORDER: 
                    StartOrderClient(client);
                    break;
                case COMPLETE_ORDER:
                    FinishOrderClient(client);
                    break;
                case HANDLE_DELIVERER:
                    HandleDeliverers(client);
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
   /// A method for the client to add items to his restaurant menu.
   /// </summary>
   /// <param name="client">The restaurant owner.</param>
   private void AddItem(Client client)
   {
       string itemName;
       double itemPrice;
   
       CmdLineUI.DisplayMessage("This is your restaurant's current menu:");
       
       foreach (var item in client.Restaurant.RestaurantItems) 
       {
           CmdLineUI.DisplayMessage($" {item.ItemPrice:C2}  {item.ItemName}"); 
       }
       CmdLineUI.DisplayMessage("Please enter the name of the new item (blank to cancel):");
       itemName = CmdLineUI.GetString();
   
       if (string.IsNullOrWhiteSpace(itemName))
       {
           // do nothing 
       }
       else
       {
           while (true)
           {
               CmdLineUI.DisplayMessage("Please enter the price of the new item (without the $):");
               string input = CmdLineUI.GetString();
   
               if (!double.TryParse(input, out itemPrice))
               {
                   CmdLineUI.DisplayMessage("Invalid price.");
                   continue;
               }
               if (itemPrice <= 0.00 || itemPrice >= 1000)
               {
                   CmdLineUI.DisplayMessage("Invalid price.");
                   continue;
               }
               CmdLineUI.DisplayMessage($"Successfully added {itemName} ({itemPrice:C2}) to menu.");
               break;
           }
           // Add to list, allowing duplicates
           client.Restaurant.RestaurantItems.Add(new Item(itemName, itemPrice));
       }
   }
   
   /// <summary>
   /// A method for the client to see the customers. 
   /// </summary>
   /// <param name="client">The client seeing the order for his restaurant.</param>
   private void SeeOrderClient(Client client)
   {
       if (client == null || client.Restaurant == null)
       {
           CmdLineUI.DisplayMessage("Invalid client or restaurant.");
           return;
       }
       string restaurantName = client.Restaurant.RestaurantName;
       var ordersForRestaurant = arribaEatsData.AllOrders
           .Where(order => order.Restaurant.RestaurantName == restaurantName)
           .OrderBy(order => order.OrderID)
           .ToList();
       if (ordersForRestaurant.Count == 0)
       {
           CmdLineUI.DisplayMessage($"Your restaurant has no current orders.");
           return;
       }
       foreach (var order in ordersForRestaurant)
       {
           CmdLineUI.DisplayMessage($"Order #{order.OrderID} for {order.Customer.Name} : {OrderStatus.Ordered}");
           foreach (var item in order.Items)
           {
               CmdLineUI.DisplayMessage($"  {item.ItemQuantity} x {item.ItemName}");
           }
       }
   }
    /// <summary>
    /// A method for the client to start cooking the order
    /// </summary>
    /// <param name="client">The client who wants to start the order.</param>
    private void StartOrderClient(Client client)
    {
       CmdLineUI.DisplayMessage("Select an order once you are ready to start cooking:");
       string restaurantName = client.Restaurant.RestaurantName; // Assign the restaurant name
       var  ordersForRestaurant = arribaEatsData.AllOrders
           .Where(order => order.Restaurant.RestaurantName == restaurantName)
           .OrderBy(order => order.OrderID)
           .ToList();
       if (ordersForRestaurant.Count == 0)
       {
           CmdLineUI.DisplayMessage("Your restaurant has no current orders.");
           return;
       }
       int count = 1;
       foreach (var o in ordersForRestaurant)
       {
         CmdLineUI.DisplayMessage($"{count}: Order #{o.OrderID} for {o.Customer.Name}");  
         CmdLineUI.DisplayMessage($"{count + 1}: Return to the previous menu");
         CmdLineUI.DisplayMessage($"Please enter a choice between 1 and {count + 1}:");
         count++;
       }  
       
       int chosenOption = CmdLineUI.GetIntInRange(1, count);
       if (chosenOption == count)
       { 
           return;
       }
       Order currentOrder = ordersForRestaurant[chosenOption - 1];
       CmdLineUI.DisplayMessage($"Order #{currentOrder.OrderID} is now marked as cooking. Please prepare the order, then mark it as finished cooking:");
       foreach(var item in currentOrder.Items)
       { 
           CmdLineUI.DisplayMessage($"  {item.ItemQuantity} x {item.ItemName}");
       }
    }
    /// <summary>
    /// A method for the client to finish the order placed by the customer, and 
    /// </summary>
    /// <param name="client">The client who wants to start the order.</param>
    private void FinishOrderClient(Client client)
    {
        CmdLineUI.DisplayMessage("Select an order once you have finished preparing it:");
        string  restaurantName = client.Restaurant.RestaurantName;
        var cookingOrders = arribaEatsData.AllOrders
                .Where(order => order.Restaurant.RestaurantName == restaurantName)
                .OrderBy(order => order.OrderID)
                .ToList();
   
        if (cookingOrders.Count == 0)
        {
            CmdLineUI.DisplayMessage("Your restaurant has no current orders.");
        }
        
        int count = 1;
        foreach (var o in cookingOrders)
        {
            CmdLineUI.DisplayMessage($"{count}: Order #{o.OrderID} for {o.Customer.Name}");  
            CmdLineUI.DisplayMessage($"{count + 1}: Return to the previous menu");
            CmdLineUI.DisplayMessage($"Please enter a choice between 1 and {count + 1}:");
            count++;
        }  
        int chosenOption = CmdLineUI.GetIntInRange(1, count);
        if (chosenOption == count)
        { 
            return;
        }
        Order currentOrder = cookingOrders[chosenOption - 1];
        CmdLineUI.DisplayMessage($"Order #{currentOrder.OrderID} is now ready for collection.");
        if (currentOrder.deliverer != null)
        {
            CmdLineUI.DisplayMessage(
                $"The deliverer with licence plate {currentOrder.deliverer.LicencePlate} will be arriving soon to collect it.");
        }
        else
        {
            CmdLineUI.DisplayMessage("No deliverer has been assigned yet.");
        }
    }
    /// <summary>
    /// A method for handling deliverers who have arrived at the restaurant
    /// </summary>
    /// <param name="client">The restaurant owner (client).</param>
    private void HandleDeliverers(Client client)
    {
        CmdLineUI.DisplayMessage("These deliverers have arrived and are waiting to collect orders.");
        CmdLineUI.DisplayMessage("Select an order to indicate that the deliverer has collected it:");
        string  restaurantName = client.Restaurant.RestaurantName;
        var handleOrders = arribaEatsData.AllOrders
            .Where(order => order.Restaurant.RestaurantName == restaurantName)
            .OrderBy(order => order.OrderID)
            .ToList();
        int count = 1;
   
        foreach (var o in handleOrders) //For each order in HandleOrders variable
        {
            CmdLineUI.DisplayMessage($"{count}:  Order #{o.OrderID} for {o.Customer.Name} (Deliverer licence plate: " +
                                     $"{o.deliverer.LicencePlate})" + $"(Order status: {OrderStatus.Cooked})");
        
            CmdLineUI.DisplayMessage($"{count + 1}: Return to the previous menu");
            CmdLineUI.DisplayMessage($"Please enter a choice between 1 and {count + 1}:");
            count++;
        }
        int chosenOption = CmdLineUI.GetIntInRange(1, count);
        if (chosenOption == count)
        { 
            return;
        }
        Order currentOrder = handleOrders[chosenOption - 1];
        CmdLineUI.DisplayMessage($"Order #{currentOrder.OrderID} is now marked as being delivered.");
    }
}