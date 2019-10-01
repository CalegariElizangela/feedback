using System;

namespace _2k_Survey.Core.Entities
{
    public class ResponseItem
    {
        public int ResponseItemId { get; set; }
        public int ResponseId { get; set; }
        public int SurveyItemId { get; set; }
        public string TextAnswer { get; set; }

        public Response Response { get; set; }
        public SurveyItem SurveyItem { get; set; }
    }
}
