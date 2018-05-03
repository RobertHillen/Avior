using System.Linq;
using Avior.Base.Helpers;
using Avior.Database.Entity;

namespace Avior.Business.UnitOfWork.Extensions
{
    public static class PlayerExtensions
    {
        public static Players GetById(this IQueryable<Players> collection, int id)
        {
            var player = collection.SingleOrDefault(e => e.Id == id);
            if (player == null)
            {
                throw ExceptionHelper.CreateAviorDataNotFoundException(Resources.Player.ExceptionEntityDescription, id, Resources.Player.ExceptionIdentifierDescriptionId);
            }

            return player;
        }
    }
}
