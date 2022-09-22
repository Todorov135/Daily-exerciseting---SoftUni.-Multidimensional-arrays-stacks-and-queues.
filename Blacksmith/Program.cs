using System;
using System.Collections.Generic;
using System.Linq;

namespace Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> swordsTypeAndResurces = new Dictionary<string, int>() 
            { 
                { "Gladius", 70 },
                { "Shamshir", 80},
                { "Katana", 90},
                { "Sabre", 110},
                { "Broadsword", 150}
            };
            Dictionary<string, int> swordsCounter = new Dictionary<string, int>()
            {
                { "Gladius", 0 },
                { "Shamshir", 0},
                { "Katana", 0},
                { "Sabre", 0},
                { "Broadsword", 0}
            };

            Queue<int> steel = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> carbon = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            while (steel.Count >0 && carbon.Count> 0) 
            {
                int currSteel = steel.Peek();
                int currCarbon = carbon.Peek();
                int sum = currSteel + currCarbon;

                if (sum == swordsTypeAndResurces["Gladius"])
                {
                    swordsCounter["Gladius"]++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (sum == swordsTypeAndResurces["Shamshir"])
                {
                    swordsCounter["Shamshir"]++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (sum == swordsTypeAndResurces["Katana"])
                {
                    swordsCounter["Katana"]++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (sum == swordsTypeAndResurces["Sabre"])
                {
                    swordsCounter["Sabre"]++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (sum == swordsTypeAndResurces["Broadsword"])
                {
                    swordsCounter["Broadsword"]++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else
                {
                    steel.Dequeue();
                    currCarbon += 5;
                    carbon.Pop();
                    carbon.Push(currCarbon);

                }

            }
            int totalSwords = swordsCounter.Sum(s => s.Value);
            if (totalSwords ==0)
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }
            else
            {
                Console.WriteLine($"You have forged {totalSwords} swords.");
            }
            if (steel.Count>0)
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }
            if (carbon.Count > 0)
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }
            swordsCounter = swordsCounter.Where(s=>s.Value != 0).OrderBy(s => s.Key).ToDictionary(s=>s.Key, v => v.Value);
            foreach (var sword in swordsCounter)
            {
                Console.WriteLine($"{sword.Key}: {sword.Value}");
            }
        }
    }
}
