using MediSchedApi.Interfaces;

namespace MediSchedApi.Repository
{
    public class ConsultationNotifier : ISubject
    {
        private readonly List<IObserver> _observers = new List<IObserver>();

        public void AddObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public async Task NotifyObservers(string email, string subject, string statusConsultation)
        {
            foreach (var observer in _observers)
            {
                await observer.Update(email, subject, statusConsultation);
            }
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }
    }
}