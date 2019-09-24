using _2k_Survey.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2k_Survey.Core.Entities
{
    public class Related_Survey
    {
        public int RelatedSurveyId { get; set; }
        public int TokenId { get; set; }
        public int ResponseId { get; set; }
        public int SurveyId { get; set; }
        public virtual Token Token { get; set; }
        public virtual Survey Survey { get; set; }
    }
}
