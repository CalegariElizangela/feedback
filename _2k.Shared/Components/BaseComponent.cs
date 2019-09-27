using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

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
            var buildDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (SubComponents.Count > 0)
                return Template.Replace("{ContentRender}", SubComponents.Select(x => x.GetHTML()).Aggregate((first, second) => first + second))
                    .Replace("{StyleRender}", File.ReadAllText(buildDir + @"\Content\survey.css"));

            return Template.Replace("{ContentRender}", "").Replace("{StyleRender}", "");
        }

        public abstract string Template { get; }
    }
}
