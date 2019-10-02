using _2k_Shared.Views;
using _2k_Survey.Attribute;
using _2k_Survey.Core.DAO.Interfaces.Repositories;
using _2k_Survey.Core.Entities;
using _2k_Survey.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _2k_Survey.Controllers
{
    public class FeedBackController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ISurveyRepository _surveyRepository;
        private readonly ITokenRepository _tokenRepository;
        private readonly IQuestionOptionRepository _questionOptionRepository;
        private readonly IResponseRepository _responseRepository;

        public FeedBackController(IMapper mapper,
            ISurveyRepository surveyRepository,
            ITokenRepository tokenRepository,
            IQuestionOptionRepository questionOptionRepository,
            IResponseRepository responseRepository)
        {
            _mapper = mapper;
            _surveyRepository = surveyRepository;
            _tokenRepository = tokenRepository;
            _questionOptionRepository = questionOptionRepository;
            _responseRepository = responseRepository;
        }

        [AllowAnonymousByToken]
        public IActionResult Index(string token)
        {
            var model = _tokenRepository.GetToken(token);

            return View("Index", CreateSurveyViewModel(model));
        }

        [AllowAnonymousByToken]
        public IActionResult OpenEditSurvey(int surveyId, int responseId)
        {
            return View("Survey", GetSurveyData(surveyId, responseId));
        }

        [AllowAnonymousByToken]
        public IActionResult OpenReadSurvey(int surveyId, int responseId)
        {
            SurveyViewModel viewModel = GetSurveyData(surveyId, responseId);

            viewModel.Answers = _responseRepository.GetResponse(responseId).ResponseItems.Select(s => s.SurveyItemId).ToArray();
            viewModel.Disabled = "disabled";

            return View("Survey", viewModel);
        }

        [HttpPost]
        public IActionResult SendFeedback([FromBody] FeedbackResponseDTO result)
        {
            try
            {
                var response = _responseRepository.GetResponse(result.ResponseId);
                response.CreateDate = DateTime.Now;

                foreach (var answer in result.FeedbackResult)
                {
                    response.ResponseItems.Add(new ResponseItem
                    {
                        ResponseId = result.ResponseId,
                        SurveyItemId = answer
                    });
                }

                _responseRepository.Update(response);

                return View("ThankYou");
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu algum erro");
            }
        }

        [AllowAnonymousByToken]
        public IActionResult ThankYou()
        {
            return View();
        }

        public IActionResult Unathorized()
        {
            return View();
        }

        #region .:Private:.
        private SurveyViewModel GetSurveyData(int surveyId, int responseId)
        {
            var survey = _surveyRepository.GetSurveyById(surveyId);

            var viewModel = _mapper.Map<SurveyViewModel>(survey);
            viewModel.ResponseId = responseId;

            foreach (var group in viewModel.Groups)
            {
                group.Questions = _mapper.Map<List<QuestionViewModel>>(survey.SurveyItems
                    .Where(w => w.GroupId == group.GroupId)
                    .OrderBy(o => o.QuestionOrder)
                    .Select(s => s.Question)
                    .Distinct());

                foreach (var question in group.Questions)
                {
                    question.Options = _mapper.Map<List<QuestionOptionsViewModel>>(survey.SurveyItems
                        .Where(w => w.QuestionId == question.QuestionId)
                        .OrderBy(o => o.QuestionOptionOrder)
                        .Select(s => s.QuestionOption)
                        .Distinct());

                    foreach (var option in question.Options)
                    {
                        option.QuestionId = question.QuestionId;
                        option.SurveyItemId = survey.SurveyItems.FirstOrDefault(w => w.GroupId == group.GroupId
                                            && w.QuestionId == question.QuestionId
                                            && w.QuestionOptionId == option.QuestionOptionId).SurveyItemId;
                    }
                }
                group.OptionsTitle.AddRange(group.Questions.FirstOrDefault().Options.Select(s => s.Content));
            }

            return viewModel;
        }

        private static List<SurveyViewModel> CreateSurveyViewModel(Token model)
        {
            var viewModel = new List<SurveyViewModel>();

            foreach (var survey in model.Related_Surveys)
            {
                viewModel.Add(new SurveyViewModel
                {
                    Token = survey.Token.Value,
                    SurveyId = survey.SurveyId,
                    ResponseId = survey.ResponseId,
                    Name = survey.Survey.Name,
                    Disabled = survey.Response.CreateDate.HasValue ? "disabled" : ""
                });
            }

            return viewModel;
        }
        #endregion
    }
}
