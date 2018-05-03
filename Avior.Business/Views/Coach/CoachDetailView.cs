using Avior.Business.Views.Player;
using Avior.Business.Views.Team;

namespace Avior.Business.Views.Coach
{
    public class CoachDetailView
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public TeamView Team { get; set; }

        public PlayerView[] Players { get; set; }
    }
}
