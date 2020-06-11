using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            View.InputValidation(args);

            Key.CreateKey();
            Rules.CreateRules(args);

            string computerMove = args[new Random().Next(0, args.Length)];  
            
            Key.CreateHMAC(computerMove);
            View.OutputHMAC();
            
            while (true)
            {
                View.Menu(args);
                bool move = int.TryParse(Console.ReadLine(), out int i);
                if(i <= args.Length && i >= 0)
                {
                    if (i == 0)
                    {
                        Environment.Exit(0);
                    }

                    string youMove = args[i - 1];

                    Console.WriteLine("You move " + youMove);
                    Console.WriteLine("Computer move " + computerMove);

                    var result = Rules.PostRule.Where(c => c.Key == i).Where(x => x.Value.Any(m => m == computerMove)).ToList();

                    if (youMove.Equals(computerMove))
                    {
                        Console.WriteLine("Drawn games");
                    }
                    else if (result.Count != 0)
                    {
                        Console.WriteLine("You Win");
                    }
                    else
                    {
                        Console.WriteLine("Computer Win");
                    }
                    View.OutputHMACKey();
                    Environment.Exit(0);
                }
            }
        }
    }
}
