using Avior.Business.Commands.Coach;
using Avior.Business.Views.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Avior.Models.Coaches
{
    public class CoachEditModel
    {
        public EditCoachCommand Command { get; set; }

        public TeamHtmlSelectView[] Teams { get; set; }
    }
}