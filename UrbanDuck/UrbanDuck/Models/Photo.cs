using System.ComponentModel.DataAnnotations;

namespace UrbanDuck.Models
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }

        public string Path { get; set; }

        public virtual Listing Listing { get; set; }
    }
}
