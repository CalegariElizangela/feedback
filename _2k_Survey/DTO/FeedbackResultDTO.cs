using Newtonsoft.Json;

namespace _2k_Survey.DTO
{
    public class FeedbackResultDTO
    {
        [JsonProperty("questionId")]
        public string QuestionId { get; set; }

        [JsonProperty("surveyItemId")]
        public string SurveyItemId { get; set; }
    }
}
