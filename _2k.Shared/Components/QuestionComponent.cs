using _2k_Shared.Views;
using System.Linq;

namespace _2k_Shared.Components
{
    public class QuestionComponent : BaseComponent
    {
        private QuestionViewModel _question;
        
        public QuestionComponent(QuestionViewModel question)
        {
            _question = question;
            question.Options.Select(s => new OptionComponent(s)).ToList().ForEach(g => AddSubComponent(g));
        }

        public override string Template =>
        $@"<tr>
            <th class=""questionCol"">
                {_question.Content}
            </th>
            {{ContentRender}}
        </tr>
        ";
    }
}
