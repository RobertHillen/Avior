using System.ComponentModel.DataAnnotations;
using Avior.Business.Attributes;
using Avior.Business.UnitOfWork;
using Avior.Database.Entity;
using Avior.Base;
using Avior.Base.Interfaces;
using Avior.Business.UnitOfWork.Extensions;

namespace Avior.Business.Commands.Coach
{
    public class AddCoachCommand
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "ListLabelName", ResourceType = typeof(Resources.Coach))]
        public string Name { get; set; }

        [StringLength(20)]
        [PhoneNumber]
        [Display(Name = "ListLabelPhone", ResourceType = typeof(Resources.Coach))]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        [EmailAddress]
        [Display(Name = "ListLabelEmail", ResourceType = typeof(Resources.Coach))]
        public string Email { get; set; }

        public int TeamId { get; set; }
    }

    public sealed class AddCoachCommandHandler : ICommandHandler<AddCoachCommand>
    {
        private readonly IDataUnitOfWork uow;

        public AddCoachCommandHandler(IDataUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void Handle(AddCoachCommand command)
        {
            uow.Coaches.AddObject(new Coaches
            {
                Name = command.Name,
                Email = command.Email,
                PhoneNumber = command.PhoneNumber,
                Team = command.TeamId != Constants.Invalid_Id ? uow.Teams.GetById(command.TeamId) : null,
            });

            uow.SaveChanges();
        }
    }
}
