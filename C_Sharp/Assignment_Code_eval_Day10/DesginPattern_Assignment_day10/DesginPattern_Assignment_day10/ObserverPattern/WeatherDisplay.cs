using System;
using System.Collections.Generic;
using System.Text;

namespace DesginPattern_Assignment_day10.ObserverPattern
{
    public class WeatherDisplay : IObserver
    {
        private string name;

        public WeatherDisplay(string name)
        {
            this.name = name;
        }

        public void Update(float temperature)
        {
            Console.WriteLine($"{name} Display: Temperature updated to {temperature}°C");
        }
    }
}
