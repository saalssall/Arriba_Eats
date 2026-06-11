using System.Data.SqlTypes;
using System.Globalization;
using System.Net.Sockets;
using System.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;


namespace A2;

using System.Text.RegularExpressions;

public class Menu
{
    // public Customer CurrentCustomer;

    // private ArribaEatsData arribaEatsData;
    private bool assigned;
    // Creating a list to store the user's information
    //private List<User> users = new ();

    // creating a list for clients
    // private List<Client> clients = new ();
    //private List<Client> clients = [];

    // private List<Restaurant> restaurants = new ();

    // A list to store all orders
    //public List<Order> AllOrders = new ();

    /// <summary>
    /// Specified default menu constructor.
    /// The value of assigned is false
    /// </summary>
    public Menu()
    {
        assigned = false;
    }

    // Displaying the header
    private void DisplayHeader()
    {
        CmdLineUI.DisplayMessage("Welcome to Arriba Eats!");
    }

    /// <summary>
    /// A method for the displaying the main menu 
    /// </summary>
    /// <returns></returns>
    private bool DisplayMainMenu()
    {
        User user;
        // The main menu strings 
        const string WELCOMEMENU_STR = "Please make a choice from the menu below:"; // Welcome
        const string LOGIN_STR = "Login as a registered user"; // Menu option 1
        const string REGISTER_STR = "Register as a new user"; // Menu option 2
        const string EXIT_STR = "Exit"; // Exit

        // int for each option above
        const int LOGINUSER_INT = 0, REGISTER_INT = 1, EXIT = 2;

        // Display the menu
        int option = CmdLineUI.GetOption(WELCOMEMENU_STR, LOGIN_STR, REGISTER_STR, EXIT_STR);

        // Make selection on user input from the CmdLineUI.GetOption method
        switch (option)
        {
            // Both the CreateUserMenu and the CreateUserMenu return the value of 'true'
            // The return value is unused at the moment but could be used in the program expands  
            case LOGINUSER_INT: // If user choses 1 then proceed to the CreateUserMenu
                //user = LoginUser(users);
                break;
            case REGISTER_INT: // If user choses 2 then proceed to the RegisterUser
                //RegisterUserMenu();
                break;
            case EXIT:
                CmdLineUI.DisplayMessage("Thank you for using Arriba Eats!");
                return
                    false; // Return false to the Run method, this will stop the loop and will ultimately exit the program 
                break;
            default:
                Console.WriteLine("Wrong main menu choice");
                break;
        }

        // Both the LoginUserMenu amd the RegisterUserMenu will break from the switch 
        // statement and will then return true. This will mean that the loop in the 
        // Run method will keep displaying the main menu
        return true;
    }
    public void Run()
    {
        DisplayHeader();
        bool keepGoing = true;
        // Keep running the menu until the user chooses to exit the program
        // This will be when the user selects exit in the DisplayMainMenu method
        while (keepGoing)
        {
            keepGoing = DisplayMainMenu();
        }
        
    }
    /// Problem: Menu God class
    /// Solution: Split each menu into their designated classes
    /// Do this by: Moving methods to new classes and making sure that they pass on the instance of ArribaEatsData
    /// So that they can have access to the main list. Make sure to pass the instance through the constructor of each
    /// new menu class thats gets created.
}