using Models;
using Microsoft.EntityFrameworkCore;

public class Lab5_RetrieveData
{
    public static async Task RunAsync()
    {
        Console.WriteLine("\n Lab 5: Retrieve Product Data");

        using var context = new AppDbContext();

        // 1️⃣ Retrieve All Products
        var products = await context.Products
            .Include(p => p.Category)
            .ToListAsync();

        Console.WriteLine("\nAll Products:");
        foreach (var p in products)
            Console.WriteLine($"- {p.Name} (₹{p.Price}) - Category: {p.Category?.Name}");

        // 2️⃣ Find Product by ID
        var productById = await context.Products.FindAsync(1);
        Console.WriteLine($"\nProduct with ID 1: {productById?.Name ?? "Not Found"}");

        // 3️⃣ First Expensive Product (Price > 50000)
        var expensiveProduct = await context.Products
            .FirstOrDefaultAsync(p => p.Price > 50000);

        Console.WriteLine($"\nExpensive Product (Price > ₹50,000): {expensiveProduct?.Name ?? "None"}");
    }
}
