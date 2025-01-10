using MediSchedApi.Interfaces;
using Quartz;

namespace MediSchedApi.Services
{
    public class UpdateConsultationStatusJob : IJob
    {
        private readonly IConsultationRepository _consultationRepo;
        public UpdateConsultationStatusJob(IConsultationRepository consultationRepo)
        {
            _consultationRepo = consultationRepo;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Atualizando status das consultas...");
            var currentDate = DateTime.Now;

            var consultationsToUpdate = await _consultationRepo.GetConsultationsByStatusAndDate("Agendada", currentDate);

            foreach (var consultation in consultationsToUpdate)
            {
                consultation.Status = "Finalizada";

                await _consultationRepo.UpdateConsultationStatus(consultation);
            }
        }
    }
}
