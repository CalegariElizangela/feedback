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
                    <div class=""custom-control custom-radio"">
                      <input type = ""radio"" class=""custom-control-input"" id=""{_questionOption.SurveyItemId}"" name=""question_{_questionOption.QuestionId}"">
                      <label class=""custom-control-label"" for=""{_questionOption.SurveyItemId}""></label>
                    </div>  
                </th>
            ";
    }
}