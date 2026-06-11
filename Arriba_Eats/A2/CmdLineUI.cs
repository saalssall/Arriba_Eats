using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Text.RegularExpressions.Regex;

namespace A2
{
    static class CmdLineUI
    
    {

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
        
        public static int GetInt()
        {
            string input = Console.ReadLine();
            int i = int.Parse(input);
            return i;
        }

        /// <summary>
        /// Print the message and the,
        /// Reads in a string from console, converts it to a Int32
        /// and returns the converted value
        /// </summary>
        /// <param name="msg">A message to print out</param>
        /// <returns>A Int32 representation of the users input</returns>      
        public static int GetInt(string msg)
        {
            Console.WriteLine($"{msg}");
            string input = Console.ReadLine();
            int i = int.Parse(input);
            return i;
        }
        /// <summary>
        /// Reads in a string from console and returns it
        /// </summary>
        /// <returns>A string representation of the users input</returns>
        public static string GetString()
        {
            string input = Console.ReadLine();
            return input;
        }
        /// <summary>
        /// Reads in a string from console, converts it to a double
        /// and returns the converted value
        /// </summary>
        /// <returns>A double floating point representation of the users input</returns>
        public static double GetDouble()
        {
            string input = Console.ReadLine();
            double d = Double.Parse(input);
            return d;
        }
        public static void DisplayMessage(object o)
        {
            Console.WriteLine(o.ToString());
        }

        public static int GetOption(string title, params object[] options)
        {
            // Defensive error checking - There should be at least 1 option, but we need double check.
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

            // Highlighting the importance of diversity. The upper limit will depend of the number of elements passed.
            int option = GetInt($"Please enter a choice between 1 and {options.Length}:");

            // need to subtract 1 to align because programers count from zero 
            return option - 1; 
        }

        
    }
}