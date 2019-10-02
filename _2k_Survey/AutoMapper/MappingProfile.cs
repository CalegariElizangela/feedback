using _2k_Shared.Views;
using _2k_Survey.Core.Entities;
using AutoMapper;
using System.Linq;

namespace _2k_Survey.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Survey, SurveyViewModel>()
                .ForMember(x => x.Groups, op => op.MapFrom(y => y.SurveyItems
                    .OrderBy(o => o.GroupOrder)
                    .Select(s => s.Group)
                    .Distinct()));

            CreateMap<Group, GroupViewModel>();
            CreateMap<Question, QuestionViewModel>();
            CreateMap<QuestionOption, QuestionOptionsViewModel>();
        }
    }
}
