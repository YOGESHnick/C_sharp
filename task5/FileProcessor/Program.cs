using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputPath = "input.txt";
        string outputPath = "output.txt";

        try
        {
            // Read all lines from the input file
            string[] lines = File.ReadAllLines(inputPath);
            int lineCount = lines.Length;
            int wordCount = 0;

            foreach (string line in lines)
            {
                wordCount += line.Split(' ').Length;
            }

            // Prepare result
            string result = $"Line Count: {lineCount}\nWord Count: {wordCount}";

            // Write result to output file
            File.WriteAllText(outputPath, result);

            Console.WriteLine("✅ File processed successfully!");
            Console.WriteLine(result);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("❌ Error: Input file not found.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"❌ IO Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Unexpected error: {ex.Message}");
        }
    }
}
