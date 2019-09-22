using System;

namespace MovieApplication.Common.BaseTypes
{
    public class BaseEntity
    {
        public DateTime? CreatedDate { get; set; }
        public int? Creator { get; set; }
        public DateTime? ModifiedDate { get; set; }
        
    }
}
