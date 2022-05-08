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

        [StringLength(50, MinimumLength = 3)]
        public string? Title { get; set; }

        [StringLength(10000)]
        public string? Description { get; set; }

        public int? Amount { get; set; }

        public float? Price { get; set; }

        public virtual Contributor Contributor { get; set; }

        public virtual ICollection<Booking> Booking { get; set; }
    }
}
