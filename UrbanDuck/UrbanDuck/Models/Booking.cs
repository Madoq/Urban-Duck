using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UrbanDuck.Interfaces;

namespace UrbanDuck.Models
{
    public class Booking : IDbModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Listing")]
        public int ListingId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual Listing Listing { get; set; }
        public virtual User User { get; set; }
    }
}
