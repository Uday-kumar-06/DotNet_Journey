using Product_Mangement_Using_Indexer;

class Program
{
    public static void Main(string[] args)
    {
        Products product1 = new Products("Laptop", 999.99, 10);
        Products product2 = new Products("Smartphone", 499.99, 20);


        ProductCollection collection = new ProductCollection();

        collection.AddProduct(product1);
        collection.AddProduct(product2);

        Products p = collection[0];

        Console.WriteLine($"Product Name: {p.Name}, Price: {p.Price}, Quantity: {p.Quantity}");

        collection[0] = new Products("Tablet", 299.99, 15);

        Products p1 = collection[0];

        Console.WriteLine($"Product Name : {p1.Name}, Price: {p1.Price}, Quantity: {p1.Quantity}");
    }
}
