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
            var currentDate = DateTime.Now;

            var consultationsToUpdate = await _consultationRepo.GetConsultationsByStatusAndDate("agendada", currentDate);

            foreach (var consultation in consultationsToUpdate)
            {
                consultation.Status = "finalizada";

                await _consultationRepo.UpdateConsultationStatus(consultation);
            }
        }
    }
}
