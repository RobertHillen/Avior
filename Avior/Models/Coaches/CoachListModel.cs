using Avior.Business.Commands.Coach;
using Avior.Business.Views.Coach;
using Avior.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Avior.Models.Coaches
{
    public class CoachListModel
    {
        public IQueryable<CoachDetailView> CoachList { get; set; }
    }
}