using System.Linq;
using Avior.Base.Helpers;
using Avior.Database.Entity;

namespace Avior.Business.UnitOfWork.Extensions
{
    public static class CoachExtensions
    {
        public static Coaches GetById(this IQueryable<Coaches> collection, int id)
        {
            var coach = collection.SingleOrDefault(e => e.Id == id);
            if (coach == null)
            {
                throw ExceptionHelper.CreateAviorDataNotFoundException(Resources.Coach.ExceptionEntityDescription, id, Resources.Coach.ExceptionIdentifierDescriptionId);
            }

            return coach;
        }
    }
}
