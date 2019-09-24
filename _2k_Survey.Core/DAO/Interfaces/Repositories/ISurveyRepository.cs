using _2k_Survey.Core.Entities;
using System.Collections.Generic;

namespace _2k_Survey.Core.DAO.Interfaces.Repositories
{
    public interface ISurveyRepository
    {
        List<Survey> GetAllSurveysByToken(string token);
        Survey GetSurveyById(int surveyId);
        bool HasAuthorizantionByIdAndToken(int survey, string token);
    }
}
