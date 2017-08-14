using Avior.Business.Commands.Coach;
using Avior.Business.Views.Team;

namespace Avior.Models.Coaches
{
    public class CoachEditModel
    {
        public EditCoachCommand Command { get; set; }

        public TeamHtmlSelectView[] Teams { get; set; }
    }
}