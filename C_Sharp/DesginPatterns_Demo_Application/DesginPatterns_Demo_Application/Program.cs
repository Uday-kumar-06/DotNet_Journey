using DesginPatterns_Demo_Application;
using DesginPatterns_Demo_Application.Behaviour_Pattern.observer_pattern;
using DesginPatterns_Demo_Application.Creational_Patterns;
using DesginPatterns_Demo_Application.Creational_Patterns.builder_pattern;
using DesginPatterns_Demo_Application.Creational_Patterns.factory_pattern;
using DesginPatterns_Demo_Application.Creational_Patterns.singleton_pattern;
using DesginPatterns_Demo_Application.Structural_Patterns.decorator_pattern;

class Program
{
    public static void Main(string[] args)
    {
        Behaviour behaviour = new Behaviour();
        behaviour.Run();
    }
}
