using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MediSchedApi.Dtos.Consultation
{
    public class ConsultationDto
    {
        public int Id { get; set; }
        public string PacienteId { get; set; }
        public string MedicoId { get; set; }

        [JsonProperty("data")]
        public DateTime Data { get; set; }
        public string Status { get; set; }
    }
}