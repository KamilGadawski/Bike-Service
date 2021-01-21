using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeService.Models
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Surname { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DisplayName("Telephone")]
        public string TelephoneNumber { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateTimeAdd { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Last Update Customer")]
        public DateTime Edit { get; set; }
    }
}
