using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UrbanDuck.Interfaces;

namespace UrbanDuck.Models
{
    public class Address : IDbModel
    {
        [Key]
        public int Id { get; set; }

        public string? PostCode { get; set; }

        [StringLength(30)]
        public string? City { get; set; }

        [StringLength(50)]
        public string? StreetName { get; set; }

        public int? StreetNumber { get; set; }

        public int? BuildingNumber { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}
