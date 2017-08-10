using System.ComponentModel.DataAnnotations;

namespace Avior.Database.Models
{
    public class Coach
    {
        public int ID { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        public int TeamID { get; set; }
    }
}
