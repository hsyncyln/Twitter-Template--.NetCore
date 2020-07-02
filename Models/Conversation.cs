using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Twitter.Models
{
    public class Conversation
    {
        public Conversation()
        {
            SendMessages = new List<Messages>();
            TakeMessages = new List<Messages>();
        }
        public Users OtherPerson { get; set; }

        public List<Messages> SendMessages { get; set; }
        public List<Messages> TakeMessages { get; set; }
    }
}
