using User_Service.Models;

namespace User_Service.Service.Interfaces
{
    public interface IAuthService
    {
        string GenerateToken(User user);
    }
}
