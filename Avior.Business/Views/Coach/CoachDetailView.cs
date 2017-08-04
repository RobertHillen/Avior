using Avior.Base.Interfaces;
using Avior.Business.Views.Player;
using Avior.Business.Views.Team;
using System.Linq;

namespace Avior.Business.Views.Coach
{
    public class CoachDetailView
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public TeamDetailView Team { get; set; }

        public IQueryable<PlayerDetailView> Players { get; set; }
    }
}
