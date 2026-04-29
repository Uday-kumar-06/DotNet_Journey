using DesginPattern_Assignment_day10.Factory;
using DesginPattern_Assignment_day10.ObserverPattern;

class Program
{
    static void Main()
    {
        Interface1 doc1 = DocumentFactory.GetDocument("ConcreteClass1");
        doc1.Open();

        Interface1 doc2 = DocumentFactory.GetDocument("ConcreteClass2");
        doc2.Open();


        WeatherStation station = new WeatherStation();

        WeatherDisplay display1 = new WeatherDisplay("Mobile");
        WeatherDisplay display2 = new WeatherDisplay("TV");

        station.Register(display1);
        station.Register(display2);

        station.SetTemperature(30.5f);

        station.Unregister(display2);

        station.SetTemperature(28.0f);
    }
}