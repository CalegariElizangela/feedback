using _2k_Shared.Views;

namespace _2k_Shared.Components
{
    public class GroupComponent : BaseComponent
    {
        private GroupViewModel _group;

        public GroupComponent(GroupViewModel group)
        {
            _group = group;
            AddSubComponent(new GroupHeaderComponent(_group));
            AddSubComponent(new GroupBodyComponent(_group));
        }

        public override string Template => @"{ContentRender}";
    }
}
