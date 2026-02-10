using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.DesignPatterns.Observer
{
    public interface IObserver
    {
        // Gözlemciye "Log oluştur" emri vereceğimiz metot
        void CreateLog(string message, string section, string detail = null);
    }
}
