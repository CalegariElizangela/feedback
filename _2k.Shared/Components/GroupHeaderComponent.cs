using _2k_Shared.Views;
using System.Linq;

namespace _2k_Shared.Components
{
    public class GroupHeaderComponent :BaseComponent
    {
        private GroupViewModel _group;

        public GroupHeaderComponent(GroupViewModel group)
        {
            _group = group;
            group.OptionsTitle.Select(s => new OptionTitleComponent(s)).ToList().ForEach(g => AddSubComponent(g));
        }

        public override string Template =>
        $@"<tr class=""groupRow"">
            <th class=""groupCol"">
                <div class=""groupName""> {_group.Name} </div>
            </th>
            {{ContentRender}}
        </tr>
        ";
    }
}
