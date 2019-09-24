using _2k_Survey.Core.DAO;
using _2k_Survey.Core.DAO.Interfaces.Repositories;
using _2k_Survey.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace _2k_Survey.Core.DAO.Repositories
{
    public class QuestionOptionRepository : IQuestionOptionRepository
    {
        private readonly Context _context;

        public QuestionOptionRepository(Context context)
        {
            _context = context;
        }

        public List<QuestionOption> GetAll()
        {
            return _context.QuestionOptions.ToList();
        }
    }
}
