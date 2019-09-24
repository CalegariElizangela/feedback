using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _2k_Shared.Components
{
    public abstract class BaseComponent : IComponent
    {
        public List<IComponent> SubComponents { get; } = new List<IComponent>();

        public IComponent AddSubComponent(IComponent component)
        {
            SubComponents.Add(component);
            return this;
        }

        public string GetHTML()
        {
            if(SubComponents.Count > 0)
                return Template.Replace("{ContentRender}", SubComponents.Select(x => x.GetHTML()).Aggregate((first, second) => first + second))
                    .Replace("{StyleRender}", File.ReadAllText(@"C:\Projects\2k.feedback\_2k.Shared\Content\survey.css"));

            return Template.Replace("{ContentRender}", "").Replace("{StyleRender}", "");
        }

        public abstract string Template { get; }
    }
}
