using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Twitter.Models
{
    public class Messages
    {
       
        public int Id { get; set; }
        public string Message { get; set; }

        public int UserId { get; set; }
        public virtual Users User { get; set; }
        public DateTime MessageTime { get; set; }


    }
}
