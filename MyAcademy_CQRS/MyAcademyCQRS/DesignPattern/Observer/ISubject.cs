namespace MyAcademyCQRS.DesignPatterns.Observer
{
    public interface ISubject
    {
        void RegisterObserver(IObserver observer); // Abone ol
        void RemoveObserver(IObserver observer);   // Abonelikten çık
        void NotifyObservers(string message, string section, string detail = null); // Herkese haber ver
    }
}
