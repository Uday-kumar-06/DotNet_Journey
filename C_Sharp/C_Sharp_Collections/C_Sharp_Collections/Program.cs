class Products
{
    public string Category { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }

    public Products(string category, string name, double price)
    {
        Category = category;
        Name = name;
        Price = price;
    }
}

class Program{

    public static Products productSelection(string category, string name, double price)
    {
        return new Products(category, name, price);
    }

    public static void ItemsSelection(Stack<Products> productStack, Dictionary<string, Dictionary<string, int>> store)
    {
        while (true)
        {
            Console.WriteLine("Enter a command: 1,2,3 (fruits, vegetables, snacks) or 4 (exit)");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Fruits:");
                    foreach (var item in store["Fruits"])
                    {
                        Console.WriteLine($"{item.Key}: {item.Value}");
                    }
                    while (true)
                    {
                        Console.WriteLine("Select a fruit to add to the cart (or type 'back' to return):");
                        string fruitChoice = Console.ReadLine();
                        if (fruitChoice.ToLower() == "back")
                        {
                            break;
                        }
                        if (store["Fruits"].ContainsKey(fruitChoice))
                        {
                            int price = store["Fruits"][fruitChoice];
                            productStack.Push(productSelection("Fruits", fruitChoice, price));
                            Console.WriteLine($"{fruitChoice} added to the stack.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid fruit selection. Please try again.");
                        }
                    }
                    break;

                case "2":
                    Console.WriteLine("Vegetables:");
                    foreach (var item in store["Vegetables"])
                    {
                        Console.WriteLine($"{item.Key}: {item.Value}");
                    }
                    while (true)
                    {
                        Console.WriteLine("Select a vegetable to add to the cart (or type 'back' to return):");
                        string vegChoice = Console.ReadLine();
                        if (vegChoice.ToLower() == "back")
                        {
                            break;
                        }
                        if (store["Vegetables"].ContainsKey(vegChoice))
                        {
                            int price = store["Vegetables"][vegChoice];
                            productStack.Push(productSelection("Vegetables", vegChoice, price));
                            Console.WriteLine($"{vegChoice} added to the stack.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid vegetable selection. Please try again.");
                        }
                    }
                    break;

                case "3":
                    Console.WriteLine("Snacks:");
                    foreach (var item in store["Snacks"])
                    {
                        Console.WriteLine($"{item.Key}: {item.Value}");
                    }
                    while (true)
                    {
                        Console.WriteLine("Select a Snacks to add to the cart (or type 'back' to return):");
                        string snackChoice = Console.ReadLine();
                        if (snackChoice.ToLower() == "back")
                        {
                            break;
                        }
                        else if (store["Snacks"].ContainsKey(snackChoice))
                        {
                            int price = store["Snacks"][snackChoice];
                            productStack.Push(productSelection("Snacks", snackChoice, price));
                            Console.WriteLine($"{snackChoice} added to the stack.");

                        }
                        else
                        {
                            Console.WriteLine("Invalid snack selection. Please try again.");

                        }
                    }
                    break;

                case "4":
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;

            }
        }
    }
    public static void Main(string[] args)
    {
        Dictionary<string, Dictionary<string, int>> store = new Dictionary<string, Dictionary<string, int>>()
        {
            {
                "Fruits", new Dictionary<string, int>()
                {
                    {"Apple", 100},
                    {"Banana", 40},
                    {"Orange", 80},
                    {"Grapes", 120}
                }
            },
            {
                "Vegetables", new Dictionary<string, int>()
                {
                    {"Carrot", 30},
                    {"Broccoli", 60},
                    {"Spinach", 25},
                    {"Tomato", 35}
                }
            },
            {
                "Snacks", new Dictionary<string, int>()
                {
                    {"Chips", 50},
                    {"Cookies", 70},
                    {"Chocolate", 90}
                }
            }
        };
        Stack<Products> productStack = new Stack<Products>();

        ItemsSelection(productStack, store);

        Console.WriteLine("Do you Want to procced with order? (yes/no)");

        string ans = Console.ReadLine();
        Queue<Products> productQueue = new Queue<Products>(productStack);

        Queue<Dictionary<Dictionary<string, Products>, int>> cartList = new Queue<Dictionary<Dictionary<string, Products>, int>>();

        //while (productStack.Count > 0)
        //{
        //    Products product = productStack.Pop();
        //    if ()
        //}

        if (ans.ToLower() == "yes")
        {
            Console.WriteLine("Your order:");
            double total = 0;
            while (productStack.Count > 0)
            {
                Products product = productStack.Pop();
                Console.WriteLine($"{product.Name} - {product.Price}");
                total += product.Price;
            }
            Console.WriteLine($"Total: {total}");
        }
        else
        {
            Console.WriteLine("Order cancelled.");
        }
    }
}
