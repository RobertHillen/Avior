using System.Linq;
using Avior.Base.Helpers;
using Avior.Database.Models;

namespace Avior.Business.UnitOfWork.Extensions
{
    public static class CoachExtensions
    {
        public static Coach GetById(this IQueryable<Coach> collection, int id)
        {
            var coach = collection.SingleOrDefault(e => e.ID == id);
            if (coach == null)
            {
                throw ExceptionHelper.CreateAviorDataNotFoundException(Resources.Coach.ExceptionEntityDescription, id, Resources.Coach.ExceptionIdentifierDescriptionId);
            }

            return coach;
        }
    }
}
