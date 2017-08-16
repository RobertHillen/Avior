using System.ComponentModel.DataAnnotations;
using System.Linq;
using Avior.Base.Interfaces;
using Avior.Business.EntityConversions;
using Avior.Business.UnitOfWork;
using Avior.Business.Views.Player;

namespace Avior.Business.Queries.Player
{
    public class GetPlayerDetailsQuery : IQuery<PlayerDetailView>
    {
        [Required]
        public int ID { get; set; }
    }

    public sealed class GetPlayerDetailsQueryHandler : IQueryHandler<GetPlayerDetailsQuery, PlayerDetailView>
    {
        private readonly IDataUnitOfWork _uow;

        public GetPlayerDetailsQueryHandler(IDataUnitOfWork uow)
        {
            _uow = uow;
        }

        public PlayerDetailView Handle(GetPlayerDetailsQuery parameters)
        {
            return (from p in _uow.Players
                    where p.ID == parameters.ID
                    select p).SingleOrDefault().ToPlayerDisplayView();
        }
    }
}
