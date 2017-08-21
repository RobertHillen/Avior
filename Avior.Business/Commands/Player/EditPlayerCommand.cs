using System.ComponentModel.DataAnnotations;
using Avior.Base;
using Avior.Base.Interfaces;
using Avior.Business.Attributes;
using Avior.Business.UnitOfWork;
using Avior.Business.UnitOfWork.Extensions;

namespace Avior.Business.Commands.Player
{
    public class EditPlayerCommand
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "ListLabelName", ResourceType = typeof(Resources.Player))]
        public string Name { get; set; }

        [StringLength(20)]
        [PhoneNumber]
        [Display(Name = "ListLabelPhone", ResourceType = typeof(Resources.Player))]
        public string PhoneNumber { get; set; }

        public int TeamID { get; set; }
    }

    public sealed class EditPlayerCommandHandler : ICommandHandler<EditPlayerCommand>
    {
        private readonly IDataUnitOfWork uow;

        public EditPlayerCommandHandler(IDataUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void Handle(EditPlayerCommand command)
        {
            var player = uow.Players.GetById(command.ID);
            player.Name = command.Name;
            player.PhoneNumber = command.PhoneNumber;
            player.Team = command.TeamID != Constants.Invalid_Id ? uow.Teams.GetById(command.TeamID) : null;

            uow.SaveChanges();
        }
    }
}