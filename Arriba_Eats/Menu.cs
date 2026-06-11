namespace Assignment_2B;

using System.Text.RegularExpressions;

public class Menu
{
    // A boolean value for user interactions such as login 
    private bool assigned;
    private ArribaEatsData arribaEatsData; // Storing references to data
    private UserManager userManager; // Storing references to user manager 
    private ClientMenu clientMenu;
    private CustomerMenu customerMenu;
    private DelivererMenu delivererMenu;
    /// <summary>
    /// A constructor for menu to have access to data and user manager
    /// </summary>
    /// <param name="data">The data class.</param>
    /// <param name="userManager">The user manager class.</param>
    public Menu(ArribaEatsData data, UserManager userManager)
    {
        assigned = false;
        arribaEatsData = data;
        this.userManager = userManager;

        // Initialize menus based on the role or type of user
        clientMenu = new ClientMenu(arribaEatsData, userManager);
        customerMenu = new CustomerMenu(arribaEatsData, userManager);
        delivererMenu = new DelivererMenu(arribaEatsData, userManager);
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
            case LOGINUSER_INT: // If user chooses 1 then proceed to the CreateUserMenu
                userManager.LoginUsers(arribaEatsData.usersList);
                break;
            case REGISTER_INT: // If user chooses 2 then proceed to the RegisterUser
                userManager.RegisterUserMenu();
                break;
            case EXIT:
                CmdLineUI.DisplayMessage("Thank you for using Arriba Eats!");
                return false; // Return false to the Run method, this will stop the loop
                           // and will ultimately exit the program 
                break;
            default:
                Console.WriteLine("Wrong main menu choice");
                break;
        }
        return true;
    }
    
    /// <summary>
    /// Display the header and runs the menu
    /// </summary>
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
}