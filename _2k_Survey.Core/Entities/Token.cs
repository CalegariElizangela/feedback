using _2k_Survey.Core.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace _2k_Survey.Core.Entities
{
    public class Token
    {
        public int TokenId { get; set; }
        public string Value { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual ICollection<Related_Survey> Related_Surveys { get; set; }
    }
}
