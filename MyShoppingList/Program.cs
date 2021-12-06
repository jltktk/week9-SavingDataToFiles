using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            string rootDirectory = @"C:\Users\...\samples";
            Console.WriteLine("Enter store name:");
            string newDirectory = Console.ReadLine();
            Console.WriteLine("Enter shopping list name:");
            string fileName = Console.ReadLine(); ;
            string filePath = $"{rootDirectory}\\{newDirectory}";
            

            if (Directory.Exists($"{filePath}") && File.Exists($"{filePath}\\{fileName}"))
            {
                Console.WriteLine($"Directory {newDirectory} and shopping list already exists at {rootDirectory}, adding new items to existing shopping list.");
                string[] arrayFromFile = File.ReadAllLines($"{filePath}{fileName}");

                List<string> myShoppingList = arrayFromFile.ToList<string>();

                bool loopActive = true;
                while (loopActive)
                {
                    Console.WriteLine("Would you like to add an item to your current shopping list? Y/N:");
                    char userInput = Convert.ToChar(Console.ReadLine().ToLower());

                    if (userInput == 'y')
                    {
                        Console.WriteLine("Enter your item:");
                        string userItem = Console.ReadLine();
                        myShoppingList.Add(userItem);
                    }
                    else
                    {
                        loopActive = false;
                        Console.WriteLine("Take care!");
                    }
                }
                Console.Clear();

                foreach (string item in myShoppingList)
                {
                    Console.WriteLine($"Your item for shoppinglist: {item}");
                }

                File.WriteAllLines($"{filePath}{fileName}", myShoppingList);
            }
            else
            {
                //Directory.CreateDirectory($"{rootDirectory}\\{newDirectory}");
                //File.Create($"{rootDirectory}\\{newDirectory}\\{fileName}");
                List<string> newList = new List<string>(); ;

                bool loopActive = true;
                while (loopActive)
                {
                    Console.WriteLine("Would you like to add an item to your shopping list? Y/N:");
                    char userInput = Convert.ToChar(Console.ReadLine().ToLower());

                    if (userInput == 'y')
                    {
                        Console.WriteLine("Enter your item:");
                        string userItem = Console.ReadLine();
                        newList.Add(userItem);
                    }
                    else
                    {
                        loopActive = false;
                        Console.WriteLine("Take care!");
                    }
                }
                Console.Clear();

                foreach (string item in newList)
                {
                    Console.WriteLine($"Your item: {item}");
                }
                Directory.CreateDirectory($"{rootDirectory}\\{newDirectory}");
                File.Create($"{rootDirectory}\\{newDirectory}\\{fileName}");
                File.WriteAllLines($"{filePath}{fileName}", newList);

            }

        }
    }
}

