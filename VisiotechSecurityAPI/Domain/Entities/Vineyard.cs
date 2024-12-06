using System.ComponentModel.DataAnnotations;

namespace VisiotechSecurityAPI.Domain.Entity
{
    public class Vineyard
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Parcel> Parcels { get; set; } = new List<Parcel>();

    }
}
