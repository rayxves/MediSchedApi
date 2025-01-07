namespace MediSchedApi.Interfaces
{
    public interface IObserver
    {
        void Update(string email, string subject, string statusConsultation);
    }
}