using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3
{
    static class Rules
    {
        public static Dictionary<int, List<string>> PostRule { get; set; }
        
        internal static void CreateRules(string[] gameObject)
        {
            PostRule = new Dictionary<int, List<string>>();
            int center = (gameObject.Length / 2);
            for (int i = gameObject.Length; i >= 1; i--)
            {
                List<string> list = new List<string>();
                for (int numberToCenter = 1; numberToCenter <= center; numberToCenter++)
                {
                    if (i - numberToCenter >= 1)
                    {
                        list.Add(gameObject[i - numberToCenter - 1]);
                    }
                    else
                    {
                        list.Add(gameObject[gameObject.Length + i - numberToCenter - 1]);
                    }
                }
                PostRule.Add(i, list);
            }
        }
    }
}
