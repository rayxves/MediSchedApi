namespace MediSchedApi.Interfaces
{
    public interface ISubject
    {
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers(string email, string subject, string statusConsultation);
    }
}