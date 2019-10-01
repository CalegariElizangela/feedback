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

            var viewModel = new List<SurveyViewModel>();

            foreach (var survey in model.Related_Surveys)
            {
                viewModel.Add(new SurveyViewModel
                {
                    SurveyId = survey.SurveyId,
                    ResponseId = survey.ResponseId,
                    Name = survey.Survey.Name,
                    Disabled = survey.Response.CreateDate.HasValue ? "disabled" : ""
                });
            }

            ViewBag.Token = token;

            return View("Index", viewModel);
        }

        [AllowAnonymousByToken]
        public IActionResult OpenEditSurvey(int surveyId, int responseId)
        {
            SurveyViewModel viewModel = GetSurveyData(surveyId, responseId);

            return View("Survey", viewModel);
        }

        private SurveyViewModel GetSurveyData(int surveyId, int responseId)
        {
            var survey = _surveyRepository.GetSurveyById(surveyId);
            var viewModel = _mapper.Map<SurveyViewModel>(survey);
            viewModel.ResponseId = responseId;

            viewModel.Groups = _mapper.Map<List<GroupViewModel>>(survey.SurveyItems
                .OrderBy(o => o.GroupOrder)
                .Select(s => s.Group)
                .Distinct());

            foreach (var group in viewModel.Groups)
            {
                group.Questions = _mapper.Map<List<QuestionViewModel>>(survey.SurveyItems
                    .OrderBy(o => o.QuestionOrder)
                    .Where(w => w.GroupId == group.GroupId)
                    .Select(s => s.Question)
                    .Distinct());

                foreach (var question in group.Questions)
                    question.Options = _mapper.Map<List<QuestionOptionsViewModel>>(survey.SurveyItems
                        .OrderBy(o => o.QuestionOptionOrder)
                        .Where(w => w.QuestionId == question.QuestionId)
                        .Select(s => s.QuestionOption)
                        .Distinct());

                group.OptionsTitle.AddRange(group.Questions.FirstOrDefault().Options.Select(s => s.Content));

                foreach (var question in group.Questions)
                {
                    foreach (var option in question.Options)
                    {
                        option.QuestionId = question.QuestionId;
                        option.SurveyItemId = survey.SurveyItems.FirstOrDefault(w => w.GroupId == group.GroupId
                                            && w.QuestionId == question.QuestionId
                                            && w.QuestionOptionId == option.QuestionOptionId).SurveyItemId;
                    }
                }
            }

            return viewModel;
        }

        [AllowAnonymousByToken]
        public IActionResult OpenSurvey(int surveyId, int responseId)
        {
            SurveyViewModel viewModel = GetSurveyData(surveyId, responseId);

            viewModel.Answers = _responseRepository.GetResponse(responseId).ResponseItems.Select(s => s.SurveyItemId).ToArray();

            ViewBag.Disabled = true;

            return View("Survey", viewModel);
        }

        public IActionResult Unathorized()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendFeedback([FromBody] FeedbackResponseDTO feedbackResult)
        {
            try
            {
                var response = _responseRepository.GetResponse(feedbackResult.ResponseId);
                response.CreateDate = DateTime.Now;

                foreach (var answer in feedbackResult.FeedbackResult)
                {
                    response.ResponseItems.Add(new ResponseItem
                    {
                        ResponseId = feedbackResult.ResponseId,
                        SurveyItemId = answer,
                        TextAnswer = ""
                    });
                }

                _responseRepository.Update(response);

                return Redirect("ThankYouPage");
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu algum erro");
            }
        }

        [AllowAnonymousByToken]
        public IActionResult ThankYouPage()
        {
            return View();
        }
    }
}
