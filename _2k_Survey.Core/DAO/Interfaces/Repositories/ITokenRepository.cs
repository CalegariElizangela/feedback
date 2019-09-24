using _2k_Survey.Core.Entities;

namespace _2k_Survey.Core.DAO.Interfaces.Repositories
{
    public interface ITokenRepository
    {
        Token GetToken(string token);
    }
}
