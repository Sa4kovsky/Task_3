using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

namespace Task_3
{
    static class View
    {
        internal static void InputValidation(string[] gameObject)
        {
            if (gameObject.Distinct().Count() != gameObject.Length)
            {
                Console.WriteLine("All objects must be unique");
                Environment.Exit(0);
            }

            if (gameObject.Length % 2 == 0 || gameObject.Length < 3)
            {
                Console.WriteLine("Enter an odd number of objects >= 3");
                Environment.Exit(0); 
            }

        }

        internal static void Menu(string[] gameObject)
        {
            Console.WriteLine("Available moves:");
            int count = 1;
            foreach (var outputMenu in gameObject)
            {
                Console.WriteLine(count + "-" + outputMenu);
                count++;
            }
            Console.WriteLine("0-Exit");

        }

        internal static void OutputHMACKey()
        {
            Console.WriteLine("HMACKey: " + Key.HMACKey);
        }

        internal static void OutputHMAC()
        {
            Console.WriteLine("HMAC: " + Key.HMAC);
        }
    }
}
