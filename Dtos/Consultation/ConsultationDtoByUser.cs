using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MediSchedApi.Dtos.Consultation
{
    public class ToConsultationDtoByUser
    {
        public int Id { get; set; }

        [JsonProperty("data")]
        public DateTime Data { get; set; }
        public string Status { get; set; }
    }
}