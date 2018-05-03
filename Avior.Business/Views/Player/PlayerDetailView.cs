using Avior.Business.Views.Team;

namespace Avior.Business.Views.Player
{
    public class PlayerDetailView
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public TeamDetailView Team { get; set; }
    }
}
