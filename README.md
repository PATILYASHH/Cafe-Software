# Cafe Billing Software

This is a simple console-based billing software for a cafe. It allows users to view a predefined menu, select items, specify quantities, edit the order, and generate a bill with discounts and taxes applied.

## Features

- **Menu Display**: Displays the cafe menu with categories such as Main Dish (Vegetarian/Non-Vegetarian), Beverage, Dessert, Sides, and Snacks.
- **Order Items**: Users can select items from the menu, specify quantities, and add them to their order.
- **Edit Orders**: Allows users to modify quantities of the items already added to the order.
- **Bill Calculation**: The software calculates the subtotal, applies a 10% discount, and adds 8% tax to generate the final bill.
- **Customizations**: For beverages, users can choose to add extra milk or sugar.
- **Bill Printing**: Displays a detailed bill with itemized costs and the final total after discounts and tax.

## Technologies Used

- **C#**: The project is written in C# using basic console operations.
- **Collections**: Uses `List<Item>` to store menu items and ordered items.
- **Data Structures**: Uses `HashSet<string>` to handle item categories dynamically.

## How to Use

1. Clone or download the repository.
2. Open the project in Visual Studio or any C#-compatible IDE.
3. Run the `Program.cs` file to start the application.

### Steps to Use the Software:
1. **View Menu**: Upon launching the program, the menu will be displayed. You can browse through categories like Main Dish, Beverage, Dessert, Sides, and Snacks.
2. **Select Items**: Enter the item number from the menu to add it to your order.
3. **Specify Quantity**: After selecting an item, the program will ask for the quantity you wish to order.
4. **Edit Order**: If you wish to change the quantity of an item, type 'edit' and select the item you wish to modify.
5. **Complete Order**: Once you've finished selecting your items, type 'done' to finalize your order and print the bill.
6. **Print Bill**: After completing the order, the program will calculate and display the bill, including the subtotal, discount, tax, and final total.

## Sample Output

```
Welcome to the Cafe Billing Software

Menu:
-------------------------------------------------

Main Dish - Vegetarian:
1. Burger (Vegetarian) - ₹399.00
2. Veg Pizza - ₹649.00
3. Pasta (Vegetarian) - ₹599.00
-------------------------------------------------
Main Dish - Non-Vegetarian:
4. Burger (Chicken) - ₹499.00
5. Chicken Pizza - ₹749.00
6. Chicken Pasta - ₹699.00
-------------------------------------------------
Beverage:
7. Coffee - ₹199.00
8. Tea - ₹149.00
9. Juice (Orange) - ₹249.00
10. Smoothie (Mango) - ₹349.00
-------------------------------------------------
Dessert:
11. Cake - ₹299.00
12. Ice Cream (Vanilla) - ₹199.00
13. Chocolate Mousse - ₹399.00
-------------------------------------------------
Sides:
14. Fries - ₹199.00
15. Garlic Bread - ₹249.00
16. Onion Rings - ₹299.00
-------------------------------------------------
Snacks:
17. Spring Rolls - ₹349.00
18. Nachos - ₹399.00
-------------------------------------------------

Please select an item by number:
```

### Example Order:
```
Enter item number to order (or 'done' to finish, 'edit' to modify, 'print' to print bill): 1
Enter quantity for Burger (Vegetarian): 2
Would you like to add extra milk or sugar? (y/n): y
Enter item number to order (or 'done' to finish, 'edit' to modify, 'print' to print bill): done
Bill Summary:
-------------------------------------------------
Burger (Vegetarian) (with extra milk and sugar) - 2 x ₹399.00 = ₹798.00
-------------------------------------------------
Subtotal: ₹798.00
Discount (10%): -₹79.80
Tax (8%): +₹63.84
Final Total: ₹781.04
```

## License

This project is open-source and free to use. You can modify it as needed for personal or commercial purposes.

## Contributions

Feel free to contribute by forking the repository, creating issues, and submitting pull requests. All contributions are welcome!
```
https://github.com/PATILYASHH/Cafe-Software
