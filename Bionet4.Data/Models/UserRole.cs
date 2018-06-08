using System.ComponentModel.DataAnnotations;
using Bionet4.Data.Contracts;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Bionet4.Data.Models
{
    public class UserRole : IdentityUserRole, IEntity<int>
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
    }
}