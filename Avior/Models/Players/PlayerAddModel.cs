using Avior.Business.Commands.Player;
using Avior.Business.Views.Team;

namespace Avior.Models.Players
{
    public class PlayerAddModel
    {
        public AddPlayerCommand Command { get; set; }

        public TeamHtmlSelectView[] Teams { get; set; }
    }
}