using System.ComponentModel.DataAnnotations;

namespace Avior.Database.Models
{
    public class Player
    {
        public int ID { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        public int TeamID { get; set; }
    }
}
