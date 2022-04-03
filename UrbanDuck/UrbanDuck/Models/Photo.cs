using System.ComponentModel.DataAnnotations;
using UrbanDuck.Interfaces;

namespace UrbanDuck.Models
{
    public class Photo : IDbModel
    {
        [Key]
        public int Id { get; set; }

        public string Path { get; set; }

        public virtual Listing Listing { get; set; }
    }
}
