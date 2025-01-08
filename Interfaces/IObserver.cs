namespace MediSchedApi.Interfaces
{
    public interface IObserver
    {
        Task Update(string email, string subject, string statusConsultation);
    }
}