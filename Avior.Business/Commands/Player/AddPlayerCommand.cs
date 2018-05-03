using System.ComponentModel.DataAnnotations;
using Avior.Base;
using Avior.Base.Interfaces;
using Avior.Business.Attributes;
using Avior.Business.UnitOfWork;
using Avior.Business.UnitOfWork.Extensions;
using Avior.Database.Entity;

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
        [Display(Name = "ListLabelPhone", ResourceType = typeof(Resources.Player))]
        public string PhoneNumber { get; set; }

        public int TeamId { get; set; }
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
                Team = command.TeamId != Constants.Invalid_Id ? uow.Teams.GetById(command.TeamId) : null,
            });

            uow.SaveChanges();
        }
    }
}
