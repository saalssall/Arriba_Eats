namespace Assignment_2B;
using System.Text.RegularExpressions;
/// <summary>
/// A class to handle login and registration of users
/// </summary>
public class UserManager
{
    private ArribaEatsData arribaEatsData;
    
    private CustomerMenu customerMenu { get; } // A getter method for the customer menu
    private ClientMenu clientMenu { get; }
    private DelivererMenu delivererMenu { get; }

    public UserManager(ArribaEatsData arribaEatsData)
    {
        this.arribaEatsData = arribaEatsData;

        // Initialize menus 
        customerMenu = new CustomerMenu(arribaEatsData, this); //referring to the current instance of user manager
        clientMenu = new ClientMenu(arribaEatsData, this);
        delivererMenu = new DelivererMenu(arribaEatsData, this);
    }
    
    /// <summary>
    /// A menu that allow users to interact with the main menu and register as different users
    /// </summary>
    /// <returns></returns>
    public string RegisterUserMenu()
    {
        // As before add the string and integers 
        const string ADMINMENU_STR = "Which type of user would you like to register as?"; // Heading
        const string CUSTOMER_STR = "Customer"; // Option 1
        const string DELIVER_STR = "Deliverer"; // Option 2
        const string CLIENT_STR = "Client"; // Option 3
        const string RETURN_STR = "Return to the previous menu";

        const int REG_CUSTOMER = 0, REG_DELIVER = 1, REG_CLIENT = 2, RETURN_INT = 3;

        int option = CmdLineUI.GetOption(ADMINMENU_STR, CUSTOMER_STR, DELIVER_STR, CLIENT_STR, RETURN_STR);

        switch (option)
        {
            case REG_CUSTOMER:
                RegisterCustomer();
                break;
            case REG_DELIVER:
                RegisterDeliverer();
                break;
            case REG_CLIENT:
                RegisterClient();
                break;
            case RETURN_INT:
                break;
            default:
                Console.WriteLine("Wrong main menu choice");
                break;
        }
        return "";
    }
    
        
   /// <summary>
   /// A method for registering the name of users.
   /// </summary>
   /// <returns></returns>
   private string RegisterName()
   {
       string name;
       string patternName = @"^(?=.*[A-Za-z])[A-Za-z\s'-]+$"; //Regex pattern for name constraints
       do // Keep asking the user until they enter a valid input
       {
           CmdLineUI.DisplayMessage("Please enter your name:");
           name = CmdLineUI.GetString();
   
           if (!Regex.IsMatch(name, patternName))
           {
               CmdLineUI.DisplayMessage("Invalid name.");
           }
       } while (!Regex.IsMatch(name, patternName));
       return name;
   }
   
   /// <summary>
   /// A method for registering the age of users.
   /// </summary>
   /// <returns></returns>
   private int RegisterAge()
   {
       int age;
       bool isValidAge = false;
       do
       {
           CmdLineUI.DisplayMessage("Please enter your age (18-100):");
           string input = CmdLineUI.GetString();
   
           // Report to user if age is less than 18 or greater than 100
           // The string is converted to an integer value 
   
           if (int.TryParse(input, out age))
           {
               if (age >= 18 && age <= 100)
               {
                   isValidAge = true;
                   return age;
               }
               else
               {
                   CmdLineUI.DisplayMessage("Invalid age.");
               }
           }
           else
           {
               CmdLineUI.DisplayMessage("Invalid age.");
           }
       } while (!isValidAge); //Keeping asking until a valid age is entered
       return age;
   }
   
   /// <summary>
   /// A method for registering the email of users.
   /// </summary>
   /// <returns></returns>
   private string RegisterEmail()
   {
       string email;
       string patternEmail = @"^[^@]+@[^@]+$";
       do
       {
           CmdLineUI.DisplayMessage("Please enter your email address:");
           email = CmdLineUI.GetString();
           if (!Regex.IsMatch(email, patternEmail))
           {
               CmdLineUI.DisplayMessage("Invalid email address.");
           }
       } while (!Regex.IsMatch(email, patternEmail));
       return email;
   }
   
   /// <summary>
   /// A method for registering the phone number of users.
   /// </summary>
   /// <returns></returns>
   private string RegisterPhoneNumber()
   {
       string phoneNumber;
       string patternPhoneNumber = @"^0\d{9}$";
   
       do
       {
           CmdLineUI.DisplayMessage("Please enter your mobile phone number:");
           phoneNumber = CmdLineUI.GetString();
           if (!Regex.IsMatch(phoneNumber, patternPhoneNumber))
           {
               CmdLineUI.DisplayMessage("Invalid phone number.");
           }
       } while (!Regex.IsMatch(phoneNumber, patternPhoneNumber));
       return phoneNumber;
   }
   
   /// <summary>
   /// A method for registering the password of users.
   /// </summary>
   /// <returns></returns>
   private string RegisterPassword()
   {
       string password;
       string confirmPassword;
       string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$";
       while (true)
       {
           // Ask for password
           CmdLineUI.DisplayMessage("\nYour password must:" +
                                    "\n- be at least 8 characters long" +
                                    "\n- contain a number" + 
                                    "\n- contain a lowercase letter" +
                                    "\n- contain an uppercase letter");
           CmdLineUI.DisplayMessage("Please enter a password:");
           password = CmdLineUI.GetString();
   
           // Validate password format
           if (!Regex.IsMatch(password, passwordPattern))
           {
               CmdLineUI.DisplayMessage("Invalid password.");
               continue;
           }
           // Ask for confirmation
           CmdLineUI.DisplayMessage("Please confirm your password:");
           confirmPassword = CmdLineUI.GetString();
           if (password != confirmPassword)
           {
               CmdLineUI.DisplayMessage("Passwords do not match.");
               continue;
           }
           // If the response is valid and confirmed, break up the loop
           break;
       }
       return password;
   }
   
   /// <summary>
   /// A method for registering the location of some users.
   /// </summary>
   /// <returns></returns>
   private Location RegisterLocation()
   {
       string location;
       string patternLocation = @"(^-?\d+),(-?\d+)$";
       do
       {
           CmdLineUI.DisplayMessage("Please enter your location (in the form of X,Y):");
           location = CmdLineUI.GetString();
           if (!Regex.IsMatch(location, patternLocation))
           {
               CmdLineUI.DisplayMessage("Invalid location.");
           }
       } while (!Regex.IsMatch(location, patternLocation));
       Match match  = Regex.Match(location, patternLocation);
       // Converting the strings to integers and return a location object
       return new Location(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value));
   }
   
   /// <summary>
   /// A method to register the licence plate of the deliverer.
   /// </summary>
   /// <returns></returns>
   private string RegisterLicencePlate()
   {
       string licencePlate;
       string patternLicencePlate = @"^(?!\s*$)[A-Z0-9 ]{1,8}$";
       do
       {
           CmdLineUI.DisplayMessage("Please enter your licence plate:");
           licencePlate = CmdLineUI.GetString();
           if (!Regex.IsMatch(licencePlate, patternLicencePlate))
           {
               CmdLineUI.DisplayMessage("Invalid licence plate.");
           }
       } while (!Regex.IsMatch(licencePlate, patternLicencePlate));
       return licencePlate;
   }
   
   /// <summary>
   /// A method to register the restaurant.
   /// </summary>
   /// <returns></returns>
   private string RegisterRestaurantName()
   {
       string restaurantName;
       do
       {
           CmdLineUI.DisplayMessage("Please enter your restaurant's name:");
           restaurantName = CmdLineUI.GetString();
           if (String.IsNullOrWhiteSpace(restaurantName)) //Checking if the input contains only whitespaces or null
           {
               CmdLineUI.DisplayMessage("Invalid restaurant name.");
           }
       } while (String.IsNullOrWhiteSpace(restaurantName)); //Loop until the valid response is entered
       return restaurantName;
   }
   
   /// <summary>
   /// A method for the client to register his restaurant 
   /// </summary>
   /// <returns></returns>
   private string RegisterRestaurantStyle()
   {
       CmdLineUI.DisplayMessage();
       const string ADMINMENU_STR = "Please select your restaurant's style:"; 
       const string ITALY_STR = "Italian"; 
       const string FRANCE_STR = "French"; 
       const string CHINA_STR = "Chinese"; 
       const string JAPAN_STR = "Japanese";
       const string US_STR = "American";
       const string AUS_STR = "Australian";
       const int ITALIAN_RES = 0, FRENCH_RES = 1, CHINA_RES = 2, JAPAN_RES = 3, US_RES = 4, AUS_RES = 5;
       int option = CmdLineUI.GetOption(ADMINMENU_STR, ITALY_STR, FRANCE_STR, CHINA_STR, JAPAN_STR, US_STR, AUS_STR);
       
       switch (option)
       {
           case ITALIAN_RES:
               return ITALY_STR;
               break;
           case FRENCH_RES:
               return FRANCE_STR;
               break;
           case CHINA_RES:
               return CHINA_STR;
               break;
           case JAPAN_RES:
               return  JAPAN_STR;
               break;
           case US_RES:
               return US_STR;
               break;
           case AUS_RES:
               return AUS_STR;
               break;
           default:
               CmdLineUI.DisplayMessage("Wrong main menu choice");
               break;
       }
       return "";
   }
   
   /// <summary>
   /// Registering customer's details
   /// </summary>
   private void RegisterCustomer()
   {
       string type = "customer";
       string name = RegisterName();
       int age = RegisterAge();
       string email = RegisterEmail();
   
       // Checking if the email is already used by someone
       while (arribaEatsData.emailList.Contains(email))
       {
           CmdLineUI.DisplayMessage("This email address is already in use.");
           email = RegisterEmail();
       }
       
       arribaEatsData.emailList.Add(email); //Add emails to the list
       string phoneNumber = RegisterPhoneNumber();
       string password = RegisterPassword();
       Location location = RegisterLocation();
   
       // Creating a customer object
       Customer customer = new Customer(name, age, email, phoneNumber, password, location, type);
       arribaEatsData.AddEmail(email); //Add email to the list of emails
       arribaEatsData.AddUser(customer); //Add user (customer) to the user list
       CmdLineUI.DisplayMessage($"You have been successfully registered as a {type}, {name}!");
   }
   
   /// <summary>
   /// Registering clients' details
   /// </summary>
   private void RegisterClient()
   {
       string type = "client";
       string name = RegisterName();
       int age = RegisterAge();
       string email = RegisterEmail();
       string phoneNumber = RegisterPhoneNumber();
       string password = RegisterPassword();
       string restaurantName = RegisterRestaurantName();
       string restaurantStyle = RegisterRestaurantStyle();
       Location location = RegisterLocation();
       Restaurant restaurant = new Restaurant(restaurantName, location, restaurantStyle, 0.0); //Rating is 0.0 for now
       
       // Creating a client object 
       Client client = new Client(name, age, email, phoneNumber, password,
           location, type, restaurant);
   
       arribaEatsData.AddUser(client); // Adding details of the client to the user list
       arribaEatsData.AddRestaurant(restaurant); // Add details of restaurant to the restaurant list
       CmdLineUI.DisplayMessage($"You have been successfully registered as a {type}, {name}!");
   }
   
   /// <summary>
   /// Registering deliverer's details 
   /// </summary>
   private void RegisterDeliverer()
   {
       string type = "deliverer";
       string name = RegisterName();
       int age = RegisterAge();
       string email = RegisterEmail();
       string phoneNumber = RegisterPhoneNumber();
       string password = RegisterPassword();
       string licencePlate = RegisterLicencePlate();
       
       Deliverer deliverer = new Deliverer(name, age, email, phoneNumber, password, licencePlate, type);
       arribaEatsData.AddUser(deliverer);
       CmdLineUI.DisplayMessage($"You have been successfully registered as a {type}, {name}!");
   }
  
    /// <summary>
    /// A method to log in the use
    /// </summary>
    /// <param name="users">Users to login in the system using their credentials.</param>
    /// <returns></returns>
    public User LoginUsers(List<User> users)
    {
        User? user;
        // Keep asking the user for the credentials until the correct details are entered 
        do
        { 
            CmdLineUI.DisplayMessage("Email:");
            string email = (CmdLineUI.GetString() ?? "").Trim(); //Remove the whitespaces and replace the input
                                                                //with an empty string if null
            CmdLineUI.DisplayMessage("Password:");
            string password = (CmdLineUI.GetString() ?? "").Trim();
            //Find the first instance of user in the list whose password and email matches the condition
            user = users.FirstOrDefault(c => c.Email == email && c.Password == password);
        
            if (user is null)  // Handle invalid login
            {
                CmdLineUI.DisplayMessage("Invalid email or password.");
                return null;
            }
            
        } while (user is null);
        
        CmdLineUI.DisplayMessage($"Welcome back, {user.Name}!");
        
        switch (user)
        {
            case Customer customer: 
                customerMenu.RegisterCustomerMenu(customer); //If user is a customer, display their menu
                break;
            case Client client:
               clientMenu.RegisterClientMenu(client);
                break;
            case Deliverer deliverer:
                delivererMenu.RegisterDelivererMenu(deliverer);
                break;
            default:
                CmdLineUI.DisplayMessage("Wrong menu choice.");
                break;
        }
        return user;
    }
}