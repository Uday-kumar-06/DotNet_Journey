using CustomAttribute;

class program
{
    static void Main(string[] args)
    {
        var type = typeof(Sample);
        var classAttribute = (Custom)Attribute.GetCustomAttribute(type, typeof(Custom));
        if (classAttribute != null)
        {
            Console.WriteLine($"Description: {classAttribute.Description}, Version: {classAttribute.Version}");
        }
        var methodInfo = type.GetMethod("Display");
        var property = type.GetProperty("Name");
        var propertyAttribute = (Custom)Attribute.GetCustomAttribute(property, typeof(Custom));
        if(propertyAttribute != null)
        {
            Console.WriteLine($"Property Description: {propertyAttribute.Description}, Version: {propertyAttribute.Version}");
        }
        if (methodInfo != null)
        {
            var methodAttribute = (Custom)Attribute.GetCustomAttribute(methodInfo, typeof(Custom));
            if (methodAttribute != null)
            {
                Console.WriteLine($"Method Description: {methodAttribute.Description}, Version: {methodAttribute.Version}");
            }
        }
    }
}
