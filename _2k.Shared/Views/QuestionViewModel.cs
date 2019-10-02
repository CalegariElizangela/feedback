using System;
using System.Collections.Generic;

namespace _2k_Shared.Views
{
    public class QuestionViewModel
    {
        public int QuestionId { get; set; }
        public string Content { get; set; }
        public bool MultipleChoice { get; set; }

        public List<QuestionOptionsViewModel> Options { get; set; }
    }
}
