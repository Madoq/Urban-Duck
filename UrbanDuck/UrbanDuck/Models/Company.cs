using System.ComponentModel.DataAnnotations;
using UrbanDuck.Interfaces;

namespace UrbanDuck.Models
{
    public class Company : IDbModel
    {
        [Key]
        public int Id { get; set; }

        public int? NipCode { get; set; }

        [StringLength(100)]
        public string? CompanyName { get; set; }

        public virtual ICollection<Contributor> Contributors { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
