using System.ComponentModel.DataAnnotations;
using Avior.Base.Interfaces;
using Avior.Business.UnitOfWork;
using Avior.Business.UnitOfWork.Extensions;

namespace Avior.Business.Commands.Coach
{
    public class EditCoachCommand
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int TeamID { get; set; }
    }

    public sealed class EditCoachCommandHandler : ICommandHandler<EditCoachCommand>
    {
        private readonly IDataUnitOfWork uow;

        public EditCoachCommandHandler(IDataUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void Handle(EditCoachCommand command)
        {
            var coach = uow.Coaches.GetById(command.ID);
            coach.Name = command.Name;
            coach.Email = command.Email;
            coach.PhoneNumber = command.PhoneNumber;
            coach.TeamID = command.TeamID;

            uow.SaveChanges();
        }
    }
}