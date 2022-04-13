using jobsity_chat_app.DTO;
using jobsity_chat_app.DTO.Users;
using jobsity_chat_app.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace jobsity_chat_app.Services.Users
{
    public interface IUserService
    {
        public Task<List<GetUserDto>> GetAllUsers();
        public Task<GetUserDto> GetUserById(int id);
        public Task<List<GetUserDto>> AddUser(AddUserDto user);
    }
}
