using System.Collections.Generic;

namespace _2k_Survey.Core.Entities
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string Content { get; set; }
        public bool MultipleChoice { get; set; }

        public List<SurveyItem> SurveyItems { get; set; }
    }
}
