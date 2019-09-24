namespace _2k_Shared.Components
{
    public class OptionTitleComponent : BaseComponent
    {
        private string _optionTitle;

        public OptionTitleComponent(string optionTitle)
        {
            _optionTitle = optionTitle;
        }

        public override string Template =>
            $@"<th class=""titleCol"">
                {_optionTitle}
            </th>
            ";
    }
}
