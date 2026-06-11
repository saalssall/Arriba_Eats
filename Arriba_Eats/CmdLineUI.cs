namespace Assignment_2B;


    static class CmdLineUI
    
    {
        /// <summary>
        /// A static method to convert string input to int.
        /// </summary>
        /// <param name="msg">The message to display.</param>
        /// <returns></returns>
        private static int GetInt(string msg)
        {
            Console.WriteLine($"{msg}");
            string input = Console.ReadLine() ??""; //Use "" if user input is null
            int i = int.Parse(input);
            return i;
        }
        /// <summary>
        /// A method to be display messages.
        /// </summary>
        public static void DisplayMessage()
        {
            Console.WriteLine();
        }
        
        /// <summary>
        /// Displays a message to the screen.
        /// </summary>
        /// <param name="msg">The message to display</param>
        public static void DisplayMessage(string msg)
        {
            Console.WriteLine(msg);
        }
        
        /// <summary>
        /// A static method to ensure a valid integer is entered and is in a particular range
        /// </summary>
        /// <param name="min">The minimum range.</param>
        /// <param name="max">The maximum range.</param>
        /// <returns></returns>
        public static int GetIntInRange(int min, int max)
        {
            int input;
            while (true)
            {
                string? line = Console.ReadLine(); // Store the input and allow for null value
                if (int.TryParse(line, out input) && input >= min && input <= max)
                {
                    return input;
                }
                Console.WriteLine($"Invalid input. Please enter a number between {min} and {max}.");
            }
        }
        
        /// <summary>
        /// A static method to get the location
        /// </summary>
        /// <returns></returns>
        public static Location GetLocation()
        {
            string input = Console.ReadLine()??"";
            string[] parts = input.Split(','); //Split the coordinates into substrings

            int x = int.Parse(parts[0].Trim()); //Remove leading and trailing whitespaces
            int y = int.Parse(parts[1].Trim());

            return new Location(x, y);
        }
        
        /// <summary>
        /// Print the message and the,
        /// Reads in a string from console, converts it to a Int32
        /// and returns the converted value
        /// </summary>
        /// <param name="msg">A message to print out</param>
        /// <returns>A Int32 representation of the users input</returns>      
        public static int GetInt()
        {
            string input = Console.ReadLine()??"";
            int i = int.Parse(input);
            return i;
        }
        /// <summary>
        /// Reads in a string from console and returns it
        /// </summary>
        /// <returns>A string representation of the users input</returns>
        public static string GetString()
        {
            string input = Console.ReadLine()??"";
            return input;
        }
        /// <summary>
        /// Reads in a string from console, converts it to a double
        /// and returns the converted value
        /// </summary>
        /// <returns>A double floating point representation of the users input</returns>
        public static double GetDouble()
        {
            string input = Console.ReadLine()??"";
            double d = Double.Parse(input);
            return d;
        }
        public static void DisplayMessage(object o)
        {
            Console.WriteLine(o.ToString());
        }

        public static int GetOption(string title, params object[] options)
        {
            // Defensive error checking - There should be at least 1 option, but we need double-check.
            if (options.Length <= 0)
            {
                return -1;
            }

            // Setting up some formatting so the menu looks nice
            Console.WriteLine(title);
            int digitsNeeded = (int)(1 + Math.Floor(Math.Log10(options.Length)));
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{(i + 1).ToString().PadLeft(digitsNeeded)}: {options[i]}");
            }

            // Highlighting the importance of diversity. The upper limit will depend on the number of elements passed.
            int option = GetInt($"Please enter a choice between 1 and {options.Length}:");

            // need to subtract 1 to align because programmers count from zero 
            return option - 1; 
        }

        
    }
