using System.Collections.Generic;

namespace _2k_Survey.Core.Entities
{ 
    public class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }

        public List<SurveyItem> SurveyItems { get; set; }
    }
}
