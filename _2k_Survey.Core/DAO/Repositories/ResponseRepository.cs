using _2k_Survey.Core.DAO.Interfaces.Repositories;
using _2k_Survey.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace _2k_Survey.Core.DAO.Repositories
{
    public class ResponseRepository : IResponseRepository
    {
        private readonly DbSet<Response> _dbSet;
        private readonly Context _context;

        public ResponseRepository(Context context)
        {
            _dbSet = context.Response;
            _context = context;
        }

        public Response GetResponse(int responseId)
        {
            return _dbSet
                .Include(i => i.ResponseItems)
                .FirstOrDefault(x => x.ResponseId == responseId);
        }

        public void Update(Response response)
        {
            _dbSet.Attach(response);

            if (_context != null)
            {
                _context.Entry(response).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
