using jobsity_chat_app.DTO;
using jobsity_chat_app.Models;
using jobsity_chat_app.Services.Messages;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jobsity_chat_app.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        [HttpGet]
        public async Task<IActionResult> GetMessages()
        {
            return Ok(await _messageService.GetMessages());
        }
        [HttpPost]
        public async Task<IActionResult> AddMessage(Message message)
        {
            return Ok(await _messageService.AddMessage(message));
        }
    }
}
