using System;
using System.Reflection;

// Define a custom attribute
[AttributeUsage(AttributeTargets.Method)]
public class RunnableAttribute : Attribute { }

// Create sample classes with methods marked [Runnable]
public class Test1
{
    [Runnable]
    public void SayHi()
    {
        Console.WriteLine("Test1 says: Hi!");
    }

    public void NotRunnable()
    {
        Console.WriteLine("This should not be shown.");
    }
}

public class Test2
{
    [Runnable] // concept: c# looks for RunnableAttribute, this is due to naming convention
    public void Greet()
    {
        Console.WriteLine("Test2 says: Hello!");
    }
}

// Main program uses reflection to find and run methods marked with [Runnable]
class Program
{
    static void Main()
    {
        Console.WriteLine("Invoking all methods marked with [Runnable]:\n");

        // Get all types in the current assembly
        var allTypes = Assembly.GetExecutingAssembly().GetTypes();

        foreach (var type in allTypes)
        {
            // Get only public instance methods declared in the type (not inherited, not static)
            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

            foreach (var method in methods)
            {
                // Check if method has the [Runnable] attribute
                if (method.GetCustomAttribute<RunnableAttribute>() != null)
                {
                    // Create an instance of the class
                    var instance = Activator.CreateInstance(type);

                    // Invoke the method
                    method.Invoke(instance, null); // only the runnable methods are invoked
                }
            }
        }
    }
}
