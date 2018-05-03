using System.ComponentModel.DataAnnotations;
using Avior.Base.Interfaces;
using Avior.Business.UnitOfWork;
using Avior.Business.UnitOfWork.Extensions;

namespace Avior.Business.Commands.Coach
{
    public class DeleteCoachCommand
    {
        [Required]
        public int Id { get; set; }
    }

    public sealed class DeleteCoachCommandHandler : ICommandHandler<DeleteCoachCommand>
    {
        private readonly IDataUnitOfWork uow;

        public DeleteCoachCommandHandler(IDataUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void Handle(DeleteCoachCommand command)
        {
            uow.Coaches.DeleteObject(uow.Coaches.GetById(command.Id));

            uow.SaveChanges();
        }
    }
}
