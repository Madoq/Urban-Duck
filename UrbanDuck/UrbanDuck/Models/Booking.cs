using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrbanDuck.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Listing")]
        public int ListingId { get; set; }

        //[ForeignKey("User")]
        //public int UserId { get; set; }
    }
}
