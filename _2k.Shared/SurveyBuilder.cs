using _2k_Shared.Components;
using _2k_Shared.Views;

namespace _2k_Shared
{
    public class SurveyBuilder : ISurveyBuilder
    {
        public IComponent Survey { get; private set; }

        public SurveyBuilder(SurveyViewModel model)
        {
            Survey = new SurveyComponent(model);
        }

        public string GetHTML() => Survey.GetHTML();

        public static SurveyBuilder GetInstance(SurveyViewModel model) => new SurveyBuilder(model);
    }
}
