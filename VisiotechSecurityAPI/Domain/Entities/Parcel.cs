using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisiotechSecurityAPI.Domain.Entity
{
    public class Parcel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ManagerId { get; set; }

        [Required]
        public int VineyardId { get; set; }

        [Required]
        public int GrapeId { get; set; }

        [Required]
        public int YearPlanted { get; set; }

        [Required]
        public int Area { get; set; }



        [ForeignKey("ManagerId")]
        public Manager Manager { get; set; }

        [ForeignKey("VineyardId")]
        public Vineyard Vineyard { get; set; }

        [ForeignKey("GrapeId")]
        public Grape Grape { get; set; }
    }
}
