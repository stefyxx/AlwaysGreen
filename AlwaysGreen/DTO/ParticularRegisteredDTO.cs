using AlwaysGreen.Domain.Entities;
using AlwaysGreen.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace AlwaysGreen.DTO
{
    public class ParticularRegisteredDTO : ParticularUpdateDTO
    {
        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string LastName { get; set; }
    }
}
