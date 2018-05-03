using System.ComponentModel.DataAnnotations;
using Avior.Base.Interfaces;
using Avior.Business.UnitOfWork;
using Avior.Business.UnitOfWork.Extensions;

namespace Avior.Business.Commands.Player
{
    public class DeletePlayerCommand
    {
        [Required]
        public int Id { get; set; }
    }

    public sealed class DeletePlayerCommandHandler : ICommandHandler<DeletePlayerCommand>
    {
        private readonly IDataUnitOfWork uow;

        public DeletePlayerCommandHandler(IDataUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void Handle(DeletePlayerCommand command)
        {
            uow.Players.DeleteObject(uow.Players.GetById(command.Id));

            uow.SaveChanges();
        }
    }
}
