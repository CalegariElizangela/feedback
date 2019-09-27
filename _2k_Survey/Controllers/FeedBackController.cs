using _2k_Survey.Attribute;
using _2k_Shared.Views;
using _2k_Survey.Core.DAO.Interfaces.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using _2k_Survey.DTO;

namespace _2k_Survey.Controllers
{
    public class FeedBackController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ISurveyRepository _surveyRepository;
        private readonly IQuestionOptionRepository _questionOptionRepository;

        public FeedBackController(IMapper mapper,
            ISurveyRepository surveyRepository,
            IQuestionOptionRepository questionOptionRepository)
        {
            _mapper = mapper;
            _surveyRepository = surveyRepository;
            _questionOptionRepository = questionOptionRepository;
        }

        [AllowAnonymousByToken]
        public IActionResult Index(string token)
        {
            var model = _surveyRepository.GetAllSurveysByToken(token);
            var viewModel = _mapper.Map<List<SurveyViewModel>>(model);

            ViewBag.Token = token;

            return View("Index", viewModel);
        }

        [AllowAnonymousByToken]
        public IActionResult ShowSurvey(string token, int surveyId)
        {
            var survey = _surveyRepository.GetSurveyById(surveyId);
            var viewModel = _mapper.Map<SurveyViewModel>(survey);

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

            return View("Survey", viewModel);
        }

        public IActionResult Unathorized()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendFeedback([FromBody] List<FeedbackResultDTO> feedbackResult)
        {
            return View("ThankYouPage");
        }
    }
}
