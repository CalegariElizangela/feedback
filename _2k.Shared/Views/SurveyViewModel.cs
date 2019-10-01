using System.Collections.Generic;

namespace _2k_Shared.Views
{
    public class SurveyViewModel
    {
        public int SurveyId { get; set; }
        public int ResponseId { get; set; }
        public string Name { get; set; }
        public string Disabled { get; set; }
        public List<GroupViewModel> Groups { get; set; }

        public int[] Answers { get; set; }
    }
}
