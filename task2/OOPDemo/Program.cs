using System;

// Step 1: Create a Person class
class Person 
{
    public string Name { get; set; }
    public int Age { get; set; }

    // Constructor
    public Person(string name, int age) 
    {
        Name = name;
        Age = age;
    }

    // Method to introduce 
    public void Introduce() 
    {
        Console.WriteLine($"Hi, I'm {Name} and I'm {Age} years old.");
    }
}


class Program 
{
    static void Main() 
    {

        Person p1 = new Person("Alice", 25);
        Person p2 = new Person("Bob", 30);

        p1.Introduce();
        p2.Introduce();
    }
}
