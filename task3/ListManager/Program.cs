using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create a List
        List<string> items = new List<string>();

        while (true)
        {
            Console.WriteLine("\nOptions: add [item] | remove [item] | show | exit");
            Console.Write("Enter a command: ");
            
            // Input
            string input = Console.ReadLine().Trim();
            string[] parts = input.Split(' ', 2);

            if (parts.Length == 0) continue; 
            string command = parts[0].ToLower();  // get command (add, remove, show, exit)

            if (command == "add" && parts.Length > 1)  
            {
                string item = parts[1].Trim();
                items.Add(item);
                Console.WriteLine($"✅ Added: {item}");
            }
            else if (command == "remove" && parts.Length > 1)
            {
                string item = parts[1].Trim();
                if (items.Remove(item))
                    Console.WriteLine($"❌ Removed: {item}");
                else
                    Console.WriteLine($"⚠️ '{item}' not found!");
            }
            else if (command == "show")
            {
                Console.WriteLine("\n📜 List Items:");
                if (items.Count == 0) Console.WriteLine("⚠️ No items in the list.");
                foreach (string item in items)
                    Console.WriteLine($"- {item.ToUpper()}");  // Convert to uppercase
            }
            else if (command == "exit")
            {
                Console.WriteLine("Exiting program.");
                break;
            }
            else
            {
                Console.WriteLine("Invalid command! Try again.");
            }
        }
    }
}
