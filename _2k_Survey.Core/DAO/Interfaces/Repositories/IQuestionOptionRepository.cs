using _2k_Survey.Core.Entities;
using System.Collections.Generic;

namespace _2k_Survey.Core.DAO.Interfaces.Repositories
{
    public interface IQuestionOptionRepository
    {
        List<QuestionOption> GetAll();
    }
}
