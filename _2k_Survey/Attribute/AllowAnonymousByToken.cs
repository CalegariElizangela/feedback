using Microsoft.AspNetCore.Authorization;

namespace _2k_Survey.Attribute
{
    public class AllowAnonymousByToken : AuthorizeAttribute
    {
        public AllowAnonymousByToken() : base("AllowAnonymousByToken")
        { }
    }
}
