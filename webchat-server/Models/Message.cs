using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jobsity_chat_app.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        public virtual User User { get; set; }
    }
}
