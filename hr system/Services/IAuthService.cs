using hr_system.Models;

namespace hr_system.Services
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> GetTokenAsync(TokenReqModel model);

    }
}
