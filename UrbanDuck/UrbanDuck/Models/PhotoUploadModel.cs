using System.ComponentModel.DataAnnotations;
using UrbanDuck.Interfaces;

namespace UrbanDuck.Models
{
    public class PhotoUploadModel
    {
        public IFormFile photo { get; set; }
        public int listingId { get; set; }
    }
}
