using System.ComponentModel.DataAnnotations;
using Avior.Business.Attributes;
using Avior.Business.UnitOfWork;
using Avior.Database.Entity;
using Avior.Base.Interfaces;
using Avior.Business.UnitOfWork.Extensions;
using Avior.Base;

namespace Avior.Business.Commands.Player
{
    public class AddPlayerCommand
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "ListLabelName", ResourceType = typeof(Resources.Player))]
        public string Name { get; set; }

        [StringLength(20)]
        [PhoneNumber]
        [Display(Name = "ListLabelPhoneNumber", ResourceType = typeof(Resources.Player))]
        public string PhoneNumber { get; set; }

        public int TeamID { get; set; }
    }

    public sealed class AddPlayerCommandHandler : ICommandHandler<AddPlayerCommand>
    {
        private readonly IDataUnitOfWork uow;

        public AddPlayerCommandHandler(IDataUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void Handle(AddPlayerCommand command)
        {
            uow.Players.AddObject(new Players
            {
                Name = command.Name,
                PhoneNumber = command.PhoneNumber,
                Team = command.TeamID != Constants.Invalid_Id ? uow.Teams.GetById(command.TeamID) : null,
            });

            uow.SaveChanges();
        }
    }
}
