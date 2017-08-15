using Avior.Business.Commands.Coach;
using Avior.Business.Views.Team;

namespace Avior.Models.Coaches
{
    public class CoachAddModel
    {
        public AddCoachCommand Command { get; set; }

        public TeamHtmlSelectView[] Teams { get; set; }
    }
}