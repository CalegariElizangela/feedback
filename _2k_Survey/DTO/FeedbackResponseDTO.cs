using Newtonsoft.Json;

namespace _2k_Survey.DTO
{
    public class FeedbackResponseDTO
    {
        [JsonProperty("responseId")]
        public int ResponseId { get; set; }

        [JsonProperty("feedbackResult")]
        public int[] FeedbackResult { get; set; }
    }
}
