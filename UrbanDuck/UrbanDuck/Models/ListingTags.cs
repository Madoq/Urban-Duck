using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UrbanDuck.Interfaces;

namespace UrbanDuck.Models
{
    public class ListingTags
    {
        [Key]
        [ForeignKey("Listing")]
        public int ListingId { get; set; }

        public virtual Listing Listing { get; set; }

        public bool? Vegan { get; set; }

        public bool? Vegetarian { get; set; }

        public bool? Sealed { get; set; }

        public bool? Premade { get; set; }

        public bool? GlutenFree { get; set; }
    }
}
