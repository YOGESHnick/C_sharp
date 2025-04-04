using System;
using System.Collections.Generic;
using System.Linq;

// Interface for all entities
public interface IEntity
{
    int Id { get; set; }
}

// Product class implementing IEntity
public class Product : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
}

// Generic Repository class
public class Repository<T> where T : IEntity
{
    private List<T> _items = new List<T>();
    private int _nextId = 1;

    public void Add(T item)
    {
        item.Id = _nextId++;
        _items.Add(item);
    }

    public List<T> GetAll()
    {
        return _items;
    }

    public T? GetById(int id)
    {
        return _items.FirstOrDefault(i => i.Id == id);
    }

    public void Delete(int id)
    {
        var item = GetById(id);
        if (item != null)
        {
            _items.Remove(item);
        }
    }

    public void Update(T updatedItem)
    {
        var existingItem = GetById(updatedItem.Id);
        if (existingItem != null)
        {
            _items.Remove(existingItem);
            _items.Add(updatedItem);
        }
    }
}

// Program class with Main method
public class Program
{
    public static void Main(string[] args)
    {
        var repo = new Repository<Product>();

        repo.Add(new Product { Name = "Apple" });
        repo.Add(new Product { Name = "Banana" });

        Console.WriteLine("All Products:");
        foreach (var product in repo.GetAll())
        {
            Console.WriteLine($"Id: {product.Id}, Name: {product.Name}");
        }

        Console.WriteLine("\nUpdating Banana to Mango...");
        var banana = repo.GetById(2);
        if (banana != null)
        {
            banana.Name = "Mango";
            repo.Update(banana);
        }

        Console.WriteLine("\nAll Products After Update:");
        foreach (var product in repo.GetAll())
        {
            Console.WriteLine($"Id: {product.Id}, Name: {product.Name}");
        }

        Console.WriteLine("\nDeleting Apple...");
        repo.Delete(1);

        Console.WriteLine("\nFinal Products:");
        foreach (var product in repo.GetAll())
        {
            Console.WriteLine($"Id: {product.Id}, Name: {product.Name}");
        }
    }
}
