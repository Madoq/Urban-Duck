using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UrbanDuck.Interfaces;

namespace UrbanDuck.Models
{
    public class Contributor : IDbModel
    {
        [Key]
        public int Id { get; set; }

        //[ForeignKey("User")]
        //public int UserId { get; set; }

        [StringLength(30)]
        public string? FirstName { get; set; }

        [StringLength(30)]
        public string? LastName { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }

        public virtual ICollection<Listing> Listings { get; set; }

        public virtual Company Company { get; set; }
    }
}
