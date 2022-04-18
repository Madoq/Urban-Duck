using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrbanDuck.Models
{
    public class Listing
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Contributor")]
        public int ContributorId { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string? Title { get; set; }

        [StringLength(10000)]
        public string? Description { get; set; }

        public int? Amount { get; set; }

        public float? Price { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }

        public virtual Contributor Contributor { get; set; }

        public virtual Booking Booking { get; set; }
    }
}
