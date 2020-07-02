using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Twitter.Models
{
    public class Follow
    {
        public int FollowId { get; set; }
        public int MainUserId { get; set; }
        public virtual Users User { get; set; }

        public DateTime FollowDate { get; set; }


    }
}
