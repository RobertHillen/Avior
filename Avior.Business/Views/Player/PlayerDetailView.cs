using Avior.Business.Views.Coach;
using Avior.Business.Views.Team;
using Avior.Database.Entity;

namespace Avior.Business.Views.Player
{
    public class PlayerDetailView
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public TeamDetailView Team { get; set; }
    }
}
