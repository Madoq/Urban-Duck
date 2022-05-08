using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrbanDuck.Models
{
    [Table("Users")]
    public class User : IdentityUser<int>
    {
        public virtual Contributor Contributor { get; set; }
    }
}
