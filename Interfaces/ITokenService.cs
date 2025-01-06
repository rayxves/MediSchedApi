using MediSchedApi.Models;

namespace MediSchedApi.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}