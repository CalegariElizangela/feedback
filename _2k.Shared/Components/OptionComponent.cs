using _2k_Shared.Views;

namespace _2k_Shared.Components
{
    public class OptionComponent : BaseComponent
    {
        private QuestionOptionsViewModel _questionOption;
        
        public OptionComponent(QuestionOptionsViewModel questionOption)
        {
            _questionOption = questionOption;
        }

        public override string Template =>
             $@"<th class=""optionCol"">
                     <input type = ""radio"" class=""option"" id=""{_questionOption.SurveyItemId}"" name=""{_questionOption.QuestionId}"" />
                </th>
            ";
    }
}
