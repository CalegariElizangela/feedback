using _2k_Shared.Views;
using System.Linq;

namespace _2k_Shared.Components
{
    public class SurveyComponent : BaseComponent
    {
        private readonly SurveyViewModel _survey;

        public SurveyComponent(SurveyViewModel survey)
        {
            _survey = survey;
            survey.Groups.Select(s => new GroupComponent(s)).ToList().ForEach(g => AddSubComponent(g));
        }

        public override string Template =>
            $@"<style> {{StyleRender}} </style>
            <div class=""surveypage"">
                <h1 class=""title"">
                    <p>{_survey.Name}</p>
                </h1>
                <div class=""subTitle"">
                    <div><span>This survey takes 1-2 minutes to complete.</span></div>
                    <div><span>All feedback is for internal use only.</span></div>
                    <div><p>Select the <span class=""fa fa-question-circle""></span> if you would like more context around the question.</p></div>
                </div>
                <div class=""survey"">
                    <table class=""table table-striped"">
                        {{ContentRender}}
                    </table>
                    <div>
                        <strong>NOTES:</strong>
                        <div>
                            <textarea rows=""5""></textarea>
                        </div>
                    </div>
                </div>
                <div class=""sendbutton"">
                    <button type=""button"" class=""btn btn-success"" onClick=""SendFeedback()"">Send Feedback</button>
                </div>
            </div>
            ";
    }
}
