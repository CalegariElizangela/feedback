using _2k_Survey.Core.DAO.Interfaces.Repositories;
using _2k_Survey.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace _2k_Survey.Core.DAO.Repositories
{
    public class SurveyRepository : ISurveyRepository
    {
        private readonly Context _context;

        public SurveyRepository(Context context)
        {
            _context = context;
        }

        public List<Survey> GetAllSurveysByToken(string token) =>
                _context.Surveys.Where(x => x.Related_Surveys.Any(y => y.Token.Value == token)).ToList();

        public Survey GetSurveyById(int surveyId)
        {
            return _context.Surveys
                .Include(e => e.SurveyItems).ThenInclude(e => e.Group)
                .Include(e => e.SurveyItems).ThenInclude(e => e.Question)
                .Include(e => e.SurveyItems).ThenInclude(e => e.QuestionOption)
                .FirstOrDefault(f => f.SurveyId == surveyId);
        }

        public bool HasAuthorizantionByIdAndToken(int survey, string token) =>
            _context.Surveys.Where(x => x.SurveyId == survey && x.Related_Surveys.Any(y => y.Token.Value == token)).Count() > 0;
    }
}
