using _2k_Shared.Views;
using System.Linq;

namespace _2k_Shared.Components
{
    public class GroupBodyComponent :BaseComponent
    {
        private GroupViewModel _group;

        public GroupBodyComponent(GroupViewModel group)
        {
            _group = group;
            group.Questions.Select(s => new QuestionComponent(s)).ToList().ForEach(g => AddSubComponent(g));
        }

        public override string Template => @"{ContentRender}";
    }
}
