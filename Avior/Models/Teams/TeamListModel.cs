using System.Linq;
using Avior.Business.Views.Team;

namespace Avior.Models.Teams
{
    public class TeamListModel
    {
        public IQueryable<TeamDetailView> TeamList { get; set; }
    }
}
