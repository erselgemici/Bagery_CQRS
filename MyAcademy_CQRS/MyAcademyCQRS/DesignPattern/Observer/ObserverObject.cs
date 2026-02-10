using System.Collections.Generic;

namespace MyAcademyCQRS.DesignPatterns.Observer
{
    public class ObserverObject : ISubject
    {
        // Abone olan gözlemcilerin listesi
        private readonly List<IObserver> _observers;

        public ObserverObject()
        {
            _observers = new List<IObserver>();
        }

        public void RegisterObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers(string message, string section, string detail = null)
        {
            foreach (var observer in _observers)
            {
                observer.CreateLog(message, section, detail);
            }
        }
    }
}
