using Avior.Business.Commands.Player;
using Avior.Business.Views.Team;

namespace Avior.Models.Players
{
    public class PlayerEditModel
    {
        public EditPlayerCommand Command { get; set; }

        public TeamHtmlSelectView[] Teams { get; set; }
    }
}