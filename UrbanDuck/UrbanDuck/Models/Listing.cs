using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UrbanDuck.Interfaces;

namespace UrbanDuck.Models
{
    public class Listing : IDbModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Contributor")]
        public int ContributorId { get; set; }

        public string? photoPath { get; set; }
        //[ForeignKey("Photo")]
        //public int? PhotoId { get; set; }

        [ForeignKey("Address")]
        public int? AddressId { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string? Title { get; set; }

        [StringLength(10000)]
        public string? Description { get; set; }

        public int? Amount { get; set; }

        public float? Price { get; set; }

        //public virtual Photo Photo { get; set; }

        public virtual Contributor Contributor { get; set; }

        public virtual ICollection<Booking> Booking { get; set; }
        public virtual Address Address { get; set; }
    }
}
