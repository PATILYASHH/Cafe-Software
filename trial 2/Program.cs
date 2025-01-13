using System;
using System.Collections.Generic;

namespace CafeBillingSoftware
{
  class Program
  {
    static void Main(string[] args)
    {
      // Predefined menu items with categories and subcategories
      List<Item> menu = new List<Item>
            {
                new Item { Name = "Burger (Vegetarian)", Price = 399.00m, Category = "Main Dish - Vegetarian" },
                new Item { Name = "Veg Pizza", Price = 649.00m, Category = "Main Dish - Vegetarian" },
                new Item { Name = "Pasta (Vegetarian)", Price = 599.00m, Category = "Main Dish - Vegetarian" },
                new Item { Name = "Burger (Chicken)", Price = 499.00m, Category = "Main Dish - Non-Vegetarian" },
                new Item { Name = "Chicken Pizza", Price = 749.00m, Category = "Main Dish - Non-Vegetarian" },
                new Item { Name = "Chicken Pasta", Price = 699.00m, Category = "Main Dish - Non-Vegetarian" },
                new Item { Name = "Coffee", Price = 199.00m, Category = "Beverage" },
                new Item { Name = "Tea", Price = 149.00m, Category = "Beverage" },
                new Item { Name = "Juice (Orange)", Price = 249.00m, Category = "Beverage" },
                new Item { Name = "Smoothie (Mango)", Price = 349.00m, Category = "Beverage" },
                new Item { Name = "Cake", Price = 299.00m, Category = "Dessert" },
                new Item { Name = "Ice Cream (Vanilla)", Price = 199.00m, Category = "Dessert" },
                new Item { Name = "Chocolate Mousse", Price = 399.00m, Category = "Dessert" },
                new Item { Name = "Fries", Price = 199.00m, Category = "Sides" },
                new Item { Name = "Garlic Bread", Price = 249.00m, Category = "Sides" },
                new Item { Name = "Onion Rings", Price = 299.00m, Category = "Sides" },
                new Item { Name = "Spring Rolls", Price = 349.00m, Category = "Snacks" },
                new Item { Name = "Nachos", Price = 399.00m, Category = "Snacks" }
            };

      List<Item> orderedItems = new List<Item>();
      string input;

      Console.WriteLine("Welcome to the Cafe Billing Software\n");

      // Display Menu
      ShowMenu(menu);

      do
      {
        Console.WriteLine("Enter item number to order (or 'done' to finish, 'edit' to modify, 'print' to print bill): ");
        input = Console.ReadLine();

        if (input.ToLower() == "done")
          break;

        if (input.ToLower() == "edit")
        {
          EditOrder(orderedItems, menu);
          continue;
        }

        if (input.ToLower() == "print")
        {
          PrintBill(orderedItems);
          continue;
        }

        if (int.TryParse(input, out int itemNumber) && itemNumber >= 1 && itemNumber <= menu.Count)
        {
          Item selectedItem = menu[itemNumber - 1]; // Get the selected item from the menu
          Console.WriteLine($"Enter quantity for {selectedItem.Name}: ");
          if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
          {
            // Optionally add customizations like size or topping for beverages or desserts
            if (selectedItem.Category == "Beverage")
            {
              Console.WriteLine("Would you like to add extra milk or sugar? (y/n): ");
              string customization = Console.ReadLine();
              selectedItem.Name += " (with " + (customization.ToLower() == "y" ? "extra milk and sugar" : "no extra") + ")";
            }
            orderedItems.Add(new Item { Name = selectedItem.Name, Price = selectedItem.Price, Quantity = quantity });
          }
          else
          {
            Console.WriteLine("Invalid quantity. Please enter a positive integer.");
          }
        }
        else
        {
          Console.WriteLine("Invalid selection. Please select a valid item number.");
        }

      } while (input.ToLower() != "done");

      // Finalize and print bill
      PrintBill(orderedItems);
    }

    // Method to display the menu
    static void ShowMenu(List<Item> menu)
    {
      Console.WriteLine("Menu:");
      Console.WriteLine("-------------------------------------------------");

      // Group and display items by category
      var categories = new HashSet<string>(menu.ConvertAll(item => item.Category));
      foreach (var category in categories)
      {
        Console.WriteLine($"\n{category}:");
        foreach (var item in menu)
        {
          if (item.Category == category)
          {
            Console.WriteLine($"{menu.IndexOf(item) + 1}. {item.Name} - ₹{item.Price:F2}");
          }
        }
        Console.WriteLine("-------------------------------------------------");
      }
      Console.WriteLine("\nPlease select an item by number:");
    }

    // Method to edit an existing order
    static void EditOrder(List<Item> orderedItems, List<Item> menu)
    {
      Console.WriteLine("\nEnter item number to edit: ");
      string input = Console.ReadLine();
      if (int.TryParse(input, out int itemNumber) && itemNumber > 0 && itemNumber <= orderedItems.Count)
      {
        Item itemToEdit = orderedItems[itemNumber - 1];
        Console.WriteLine($"Current quantity of {itemToEdit.Name}: {itemToEdit.Quantity}");
        Console.WriteLine("Enter new quantity: ");
        if (int.TryParse(Console.ReadLine(), out int newQuantity) && newQuantity > 0)
        {
          itemToEdit.Quantity = newQuantity;
          Console.WriteLine($"Updated quantity of {itemToEdit.Name}: {itemToEdit.Quantity}");
        }
        else
        {
          Console.WriteLine("Invalid quantity.");
        }
      }
      else
      {
        Console.WriteLine("Invalid item number to edit.");
      }
    }

    // Method to print the bill
    static void PrintBill(List<Item> orderedItems)
    {
      decimal total = 0;
      decimal discount = 0.1m; // 10% discount
      decimal taxRate = 0.08m; // 8% tax
      Console.WriteLine("\nBill Summary:");
      Console.WriteLine("-------------------------------------------------");

      foreach (var item in orderedItems)
      {
        decimal itemTotal = item.Price * item.Quantity;
        total += itemTotal;
        Console.WriteLine($"{item.Name} - {item.Quantity} x ₹{item.Price:F2} = ₹{itemTotal:F2}");
      }

      decimal discountAmount = total * discount;
      decimal taxAmount = total * taxRate;
      decimal finalTotal = total - discountAmount + taxAmount;

      Console.WriteLine("-------------------------------------------------");
      Console.WriteLine($"Subtotal: ₹{total:F2}");
      Console.WriteLine($"Discount (10%): -₹{discountAmount:F2}");
      Console.WriteLine($"Tax (8%): +₹{taxAmount:F2}");
      Console.WriteLine($"Final Total: ₹{finalTotal:F2}");
    }
  }

  class Item
  {
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string Category { get; set; }  // New field for category
  }
}
