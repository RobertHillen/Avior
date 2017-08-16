using System.Linq;
using Avior.Business.Views.Player;

namespace Avior.Models.Players
{
    public class PlayerListModel
    {
        public IQueryable<PlayerDetailView> PlayerList { get; set; }
    }
}