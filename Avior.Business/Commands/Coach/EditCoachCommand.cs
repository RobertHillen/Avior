using System.ComponentModel.DataAnnotations;
using Avior.Base;
using Avior.Base.Interfaces;
using Avior.Business.UnitOfWork;
using Avior.Business.UnitOfWork.Extensions;
using Avior.Business.Attributes;

namespace Avior.Business.Commands.Coach
{
    public class EditCoachCommand
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "ListLabelName", ResourceType = typeof(Resources.Coach))]
        public string Name { get; set; }

        [StringLength(20)]
        [PhoneNumber]
        [Display(Name = "ListLabelPhoneNumber", ResourceType = typeof(Resources.Coach))]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        [EmailAddress]
        [Display(Name = "ListLabelEmail", ResourceType = typeof(Resources.Coach))]
        public string Email { get; set; }

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
            coach.Team = command.TeamID != Constants.Invalid_Id ? uow.Teams.GetById(command.TeamID) : null;

            uow.SaveChanges();
        }
    }
}