using System.Linq;
using Avior.Business.Views.Coach;

namespace Avior.Models.Coaches
{
    public class CoachListModel
    {
        public IQueryable<CoachDetailView> CoachList { get; set; }
    }
}