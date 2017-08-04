namespace Avior.Database.Models
{
    public class Coach
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int TeamID { get; set; }
    }
}
