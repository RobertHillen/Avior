using System.Linq;
using Avior.Business.Views.Player;
using Avior.Database.Entity;

namespace Avior.Business.EntityConversions
{
    internal static class PlayerConversions
    {
        internal static IQueryable<PlayerDetailView> ToPlayerListView(this IQueryable<Players> players)
        {
            return from player in players
                   select new PlayerDetailView
                   {
                       ID = player.ID,
                       Name = player.Name,
                       PhoneNumber = player.PhoneNumber,
                       Team = player.Team
                   };
        }
    }
}
