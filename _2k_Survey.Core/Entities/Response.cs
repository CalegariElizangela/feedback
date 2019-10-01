using System;
using System.Collections.Generic;

namespace _2k_Survey.Core.Entities
{
    public class Response
    {
        public int ResponseId { get; set; }
        public DateTime? CreateDate { get; set; }
        public virtual ICollection<ResponseItem> ResponseItems { get; set; }
        public virtual ICollection<Related_Survey> Related_Surveys { get; set; }
    }
}
