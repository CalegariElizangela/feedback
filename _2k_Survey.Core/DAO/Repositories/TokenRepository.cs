using _2k_Survey.Core.DAO.Interfaces.Repositories;
using _2k_Survey.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace _2k_Survey.Core.DAO.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly DbSet<Token> _dbSet;

        public TokenRepository(Context context)
        {
            _dbSet = context.Tokens;
        }

        public Token GetToken(string token)
            => _dbSet.Where(x => x.Value == token).FirstOrDefault();
    }
}
