using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jobsity_chat_app.DTO.Users
{
    public class AddUserDto
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
