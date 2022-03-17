using System.ComponentModel.DataAnnotations;

namespace UrbanDuck.Models
{
    public class Company
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
