namespace _2k_Survey.Core.Entities
{
    public class SurveyItem
    {
        public int SurveyItemId { get; set; }
        public int SurveyId { get; set; }
        public Survey Survey { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public int GroupOrder { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public int QuestionOrder { get; set; }
        public int QuestionOptionId { get; set; }
        public QuestionOption QuestionOption { get; set; }
        public int QuestionOptionOrder { get; set; }
        public bool Enabled { get; set; }
    }
}
