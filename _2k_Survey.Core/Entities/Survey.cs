using System.Collections.Generic;

namespace _2k_Survey.Core.Entities
{
    public class Survey
    {
        public int SurveyId { get; set; }
        public string Name { get; set; }
        public List<SurveyItem> SurveyItems { get; set; }
        public virtual ICollection<Related_Survey> Related_Surveys { get; set; }
    }
}
