using System.Text.Json.Serialization;

namespace ShiftTrackerAPI.Models
{
    public class NewShift
    {
        [JsonPropertyName("start")]
        public DateTime Start { get; set; }
        [JsonPropertyName("end")]
        public DateTime End { get; set; }
        [JsonPropertyName("pay")]
        public decimal Pay { get; set; }
        [JsonPropertyName("location")]
        public string Location { get; set; }
    }
}
