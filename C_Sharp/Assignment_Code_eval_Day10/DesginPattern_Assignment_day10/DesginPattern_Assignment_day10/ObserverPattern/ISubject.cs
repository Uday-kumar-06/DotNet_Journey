using System;
using System.Collections.Generic;
using System.Text;

namespace DesginPattern_Assignment_day10.ObserverPattern
{
    internal interface ISubject
    {
        void Register(IObserver observer);
        void Unregister(IObserver observer);
        void NotifyObservers();
    }
}
