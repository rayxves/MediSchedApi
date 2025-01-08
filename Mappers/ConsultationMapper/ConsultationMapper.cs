using MediSchedApi.Dtos.Consultation;

using MediSchedApi.Models;

namespace MediSchedApi.Mappers.ConsultationMapper
{
    public static class ConsultationMapper
    {
        public static ConsultationDto ToConsultationDto(this Consultation consultationModel)
        {
            if (consultationModel == null)
            {
                throw new ArgumentNullException(nameof(consultationModel));
            }


            if (consultationModel.Medico == null || consultationModel.Paciente == null)
            {
                throw new InvalidOperationException("A consulta não possui médico e/ou paciente associado.");
            }

            return new ConsultationDto
            {
                Id = consultationModel.Id,
                MedicoId = consultationModel.MedicoId,
                PacienteId = consultationModel.PacienteId,
                Data = consultationModel.Data,
                Status = consultationModel.Status
            };
        }

        public static ToConsultationDtoByUser ToConsultationDtoByUser(this Consultation consultationModel)
        {
            if (consultationModel == null)
            {
                throw new ArgumentNullException(nameof(consultationModel));
            }


            if (consultationModel.Medico == null && consultationModel.Paciente == null)
            {
                throw new InvalidOperationException("A consulta não possui médico e/ou paciente associado.");
            }

            return new ToConsultationDtoByUser
            {
                Id = consultationModel.Id,
                Data = consultationModel.Data,
                Status = consultationModel.Status
            };
        }


    }
}