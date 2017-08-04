using Avior.Business.Views.Player;
using Avior.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avior.Business.EntityConversions
{
    internal static class PlayerConversions
    {
        internal static IQueryable<PlayerDetailView> ToPlayerListView(this IQueryable<Player> players)
        {
            return from player in players
                   select new PlayerDetailView
                   {
                       ID = player.ID,
                       Name = player.Name,
                       PhoneNumber = player.PhoneNumber
                   };
        }
    }
}
