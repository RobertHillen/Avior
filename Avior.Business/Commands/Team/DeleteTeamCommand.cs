using System.ComponentModel.DataAnnotations;
using Avior.Base.Interfaces;
using Avior.Business.UnitOfWork;
using Avior.Business.UnitOfWork.Extensions;

namespace Avior.Business.Commands.Team
{
    public class DeleteTeamCommand
    {
        [Required]
        public int Id { get; set; }
    }

    public sealed class DeleteTeamCommandHandler : ICommandHandler<DeleteTeamCommand>
    {
        private readonly IDataUnitOfWork uow;

        public DeleteTeamCommandHandler(IDataUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void Handle(DeleteTeamCommand command)
        {
            uow.Teams.DeleteObject(uow.Teams.GetById(command.Id));

            uow.SaveChanges();
        }
    }
}
