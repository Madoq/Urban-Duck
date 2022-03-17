using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrbanDuck.Models
{
    public class ListingTags
    {
        [Key]
        [ForeignKey("Listing")]
        public int ListingId { get; set; }

        public virtual Listing Listing { get; set; }

        [Required]
        public bool Vegan { get; set; }

        [Required]
        public bool Vegetarian { get; set; }

        [Required]
        public bool Sealed { get; set; }

        [Required]
        public bool Premade { get; set; }

        [Required]
        public bool GlutenFree { get; set; }
    }
}
