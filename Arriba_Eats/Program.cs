namespace Assignment_2B
{
    /// <summary>
    /// The main program
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            ArribaEatsData data = new ArribaEatsData(); // Create a new instance of data 
            UserManager userManager = new UserManager(data); // Pass data to user manager
            // create the menu and run it
            Menu menu = new Menu(data, userManager);  
            menu.Run();
        }
    }
}
