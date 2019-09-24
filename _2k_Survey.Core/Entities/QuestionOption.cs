using System.Collections.Generic;

namespace _2k_Survey.Core.Entities
{
    public class QuestionOption
    {
        public int QuestionOptionId { get; set; }
        public string Content { get; set; }

        public List<SurveyItem> SurveyItems { get; set; }
    }
}
