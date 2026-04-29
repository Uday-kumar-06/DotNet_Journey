using System;
using System.Collections.Generic;
using System.Text;

namespace DesginPattern_Assignment_day10.ObserverPattern
{
    public class WeatherStation : ISubject
{
    private List<IObserver> observers = new List<IObserver>();
    private float temperature;

    public void Register(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Unregister(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void SetTemperature(float temp)
    {
        temperature = temp;
        NotifyObservers();
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(temperature);
        }
    }
}
