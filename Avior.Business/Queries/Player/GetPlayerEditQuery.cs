using System.ComponentModel.DataAnnotations;
using Avior.Base.Interfaces;
using Avior.Business.Commands.Player;
using Avior.Business.UnitOfWork;
using Avior.Business.UnitOfWork.Extensions;
using Avior.Business.EntityConversions;

namespace Avior.Business.Queries.Player
{
    public class GetPlayerEditQuery : IQuery<EditPlayerCommand>
    {
        [Required]
        public int Id { get; set; }
    }

    public sealed class GetPlayerEditQueryHandler : IQueryHandler<GetPlayerEditQuery, EditPlayerCommand>
    {
        private readonly IDataUnitOfWork uow;

        public GetPlayerEditQueryHandler(IDataUnitOfWork uow)
        {
            this.uow = uow;
        }

        public EditPlayerCommand Handle(GetPlayerEditQuery parameters)
        {
            return uow.Players.GetById(parameters.Id).ToEditPlayerCommand();
        }
    }
}
