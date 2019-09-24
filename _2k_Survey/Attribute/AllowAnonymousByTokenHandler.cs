using _2k_Survey.Helpers;
using _2k_Survey.Core.DAO.Interfaces.Repositories;
using _2k_Survey.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace _2k_Survey.Attribute
{
    public class AccountRequirement : IAuthorizationRequirement { }
    public class AllowAnonymousByTokenHandler : AuthorizationHandler<AccountRequirement>
    {
        private readonly ITokenRepository _tokenRepository;
        private readonly ISurveyRepository _surveyRepository;

        public AllowAnonymousByTokenHandler(ITokenRepository tokenRepository,
                                            ISurveyRepository surveyRepository) : base()
        {
            _tokenRepository = tokenRepository;
            _surveyRepository = surveyRepository;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AccountRequirement requirement)
        {
            var mvcContext = context.Resource as AuthorizationFilterContext;
            var (token, survey) = GetTokenAndSurveyId(mvcContext);

            var tokenFromDb = _tokenRepository.GetToken(token);

            CheckAuthorization(context, token, survey, tokenFromDb);

            context.Succeed(requirement);
            return Task.CompletedTask;
        }

        #region .:Private methods:.
        private void CheckAuthorization(AuthorizationHandlerContext context, string token, int? survey, Token tokenFromDb)
        {
            if (tokenFromDb == null)
                Unathorized(context);

            if (survey != null && !_surveyRepository.HasAuthorizantionByIdAndToken((int)survey, token))
                Unathorized(context);
        }

        private void Unathorized(AuthorizationHandlerContext context)
        {
            var redirectContext = context.Resource as AuthorizationFilterContext;
            redirectContext.Result = new RedirectToActionResult("Unathorized", "Feedback", null);
        }

        private (string, int?) GetTokenAndSurveyId(AuthorizationFilterContext mvcContext)
        {
            var token = mvcContext.GetParamsByName("token");

            var hasSurveyId = Int32.TryParse(mvcContext.GetParamsByName("surveyId"), out int surveyId);

            if (surveyId == 0) return (token, null);

            return (token, surveyId);
        }
        #endregion
    }

}
