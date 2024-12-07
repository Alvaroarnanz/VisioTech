using System.ComponentModel.DataAnnotations;

namespace VisiotechSecurityAPI.Domain.Entity
{
    public class Grape
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        // relaciones con otras tablas
        public ICollection<Parcel> Parcels { get; set; } = new List<Parcel>();

    }
}
