using System.ComponentModel.DataAnnotations;
using Avior.Base.Interfaces;
using Avior.Business.Commands.Team;
using Avior.Business.UnitOfWork;
using Avior.Business.UnitOfWork.Extensions;
using Avior.Business.EntityConversions;

namespace Avior.Business.Queries.Team
{
    public sealed class GetTeamEditQuery : IQuery<EditTeamCommand>
    {
        [Required]
        public int Id { get; set; }
    }

    public sealed class GetTeamEditQueryHandler : IQueryHandler<GetTeamEditQuery, EditTeamCommand>
    {
        private readonly IDataUnitOfWork uow;

        public GetTeamEditQueryHandler(IDataUnitOfWork uow)
        {
            this.uow = uow;
        }

        public EditTeamCommand Handle(GetTeamEditQuery parameters)
        {
            return uow.Teams.GetById(parameters.Id).ToEditTeamCommand();
        }
    }
}
