namespace Avior.Models.Coaches
{
    public class CoachUpdateRequestModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int TeamId { get; set; }
    }
}