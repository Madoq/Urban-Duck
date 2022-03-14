using System.ComponentModel.DataAnnotations;

namespace UrbanDuck.Models
{
    public class Listing
    {
        [Key]
        public int Listing_Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
    }
}
