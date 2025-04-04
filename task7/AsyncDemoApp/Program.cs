using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Fetching data from sources...\n");

        // Start all tasks concurrently
        Task<string> source1 = FetchFromSource("Source 1", 2000);
        Task<string> source2 = FetchFromSource("Source 2", 3000);
        Task<string> source3 = FetchFromSource("Source 3", 1000);

        // Wait for all tasks to complete
        string[] results = await Task.WhenAll(source1, source2, source3);

        Console.WriteLine("\nAll data fetched:");
        foreach (var result in results)
        {
            Console.WriteLine(result);
        }
    }

    static async Task<string> FetchFromSource(string name, int delay)
    {
        Console.WriteLine($"Starting to fetch from {name}...");
        await Task.Delay(delay); 
        Console.WriteLine($"{name} fetch complete.");
        return $"{name} data";
    }
}