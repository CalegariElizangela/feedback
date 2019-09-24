using System.Collections.Generic;

namespace _2k_Shared.Components
{
    public interface IComponent
    {
        List<IComponent> SubComponents { get; }
        string Template { get; }
        string GetHTML();
        IComponent AddSubComponent(IComponent component);
    }
}
