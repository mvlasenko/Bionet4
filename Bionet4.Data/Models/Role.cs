using Bionet4.Data.Contracts;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Bionet4.Data.Models
{
    public class Role : IdentityRole, IEntity<string>
    {
        
    }
}