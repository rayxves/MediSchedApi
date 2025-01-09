
using MediSchedApi.Dtos.ConsultationReport;
using MediSchedApi.Models;

namespace MediSchedApi.Mappers.ConsulationReportMapper
{
    public static class ConsulationReportMapper
    {
        public static ConsultationReportDto ToConsultationReportDto(this ConsultationReport consultationReportModel)
        {
            if (consultationReportModel == null)
            {
                throw new ArgumentNullException(nameof(consultationReportModel));
            }

            if (consultationReportModel.Medico == null)
            {
                throw new InvalidOperationException("A consulta não possui médico associado.");
            }


            if (string.IsNullOrEmpty(consultationReportModel.Medico.UserName))
            {
                throw new InvalidOperationException("O nome do médico não pode ser nulo ou vazio.");
            }

            if (consultationReportModel.DoctorSpecialty == null || consultationReportModel.DoctorSpecialty.Speciality == null)
            {
                throw new InvalidOperationException("A especialidade do médico não pode ser nula.");
            }

            return new ConsultationReportDto
            {
                Id = consultationReportModel.Id,
                UserName = consultationReportModel.Medico.UserName,
                Specialty = consultationReportModel.DoctorSpecialty.Speciality.Name,
                ConsultationCount = consultationReportModel.ConsultationCount,
                ReportDate = consultationReportModel.ReportDate
            };
        }

        public static ConsultationReportDtoBySpeciality ToConsultationReportDtoBySpeciality(this ConsultationReport consultationReportModel)
        {
            if (consultationReportModel == null)
            {
                throw new ArgumentNullException(nameof(consultationReportModel));
            }

            if (consultationReportModel.DoctorSpecialty == null || consultationReportModel.DoctorSpecialty.Speciality == null)
            {
                throw new InvalidOperationException("A especialidade do médico não pode ser nula.");
            }

            return new ConsultationReportDtoBySpeciality
            {
                Id = consultationReportModel.Id,
                Specialty = consultationReportModel.DoctorSpecialty.Speciality.Name,
                ConsultationCount = consultationReportModel.ConsultationCount,
                ReportDate = consultationReportModel.ReportDate
            };
        }



    }
}