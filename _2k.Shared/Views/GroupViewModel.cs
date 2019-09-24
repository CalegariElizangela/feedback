using System.Collections.Generic;

namespace _2k_Shared.Views
{
    public class GroupViewModel
    {
        public GroupViewModel()
        {
            OptionsTitle = new List<string>();
        }

        public int GroupId { get; set; }
        public string Name { get; set; }
        public int GroupOrder { get; set; }

        public List<string> OptionsTitle { get; set; }
        public List<QuestionViewModel> Questions { get; set; }
    }
}
