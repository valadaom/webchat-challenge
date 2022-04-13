using jobsity_chat_app.DTO;
using jobsity_chat_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jobsity_chat_app.Services.Messages
{
    public interface IMessageService
    {
        public Task<List<Message>> GetMessages();
        public Task<List<Message>> AddMessage(Message msg);
        public void AddMessageFromHub(Message msg);
    }
}
