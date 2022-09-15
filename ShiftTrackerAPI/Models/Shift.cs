using System.Text.Json.Serialization;

namespace ShiftTrackerAPI.Models
{
    public class Shift
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("start")]
        public DateTime Start { get; set; }
        [JsonPropertyName("end")]
        public DateTime End { get; set; }
        [JsonPropertyName("pay")]
        public decimal Pay { get; set; }
        [JsonPropertyName("minutes")]
        public decimal Minutes { get; set; }
        [JsonPropertyName("location")]
        public string Location { get; set; }
    }
}
