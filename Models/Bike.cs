using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BikeService.Models
{
    public class Bike
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Brand { get; set; }

        [Required]
        public int Size { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        [MaxLength(50)]
        public string Model { get; set; }

        public Guid CustomerID { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime AddedBike { get; set; }

        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }
    }
}
