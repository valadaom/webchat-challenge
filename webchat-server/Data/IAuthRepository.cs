using jobsity_chat_app.Models;
using System.Threading.Tasks;

namespace jobsity_chat_app.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> ValidateUserData(string username, string email);
    }
}