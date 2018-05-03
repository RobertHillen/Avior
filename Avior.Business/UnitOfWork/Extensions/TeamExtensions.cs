using System.Linq;
using Avior.Base.Helpers;
using Avior.Database.Entity;

namespace Avior.Business.UnitOfWork.Extensions
{
    public static class TeamExtensions
    {
        public static Teams GetById(this IQueryable<Teams> collection, int id)
        {
            var team = collection.SingleOrDefault(e => e.Id == id);
            if (team == null)
            {
                throw ExceptionHelper.CreateAviorDataNotFoundException(Resources.Team.ExceptionEntityDescription, id, Resources.Team.ExceptionIdentifierDescriptionId);
            }

            return team;
        }
    }
}
