using System;
using System.ComponentModel.DataAnnotations;
using Avior.Base.Enums;
using Avior.Base.Interfaces;
using Avior.Business.Attributes;
using Avior.Business.UnitOfWork;
using Avior.Database.Entity;

namespace Avior.Business.Commands.Team
{
    public class AddTeamCommand
    {
        [Required]
        public enuSeason Season { get; set; }

        [Required]
        public enuCategory Category { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "ListLabelName", ResourceType = typeof(Resources.Team))]
        public string Name { get; set; }

        [Required]
        public DayOfWeek TrainingDay1 { get; set; }

        [Required]
        [TimeSpan]
        [Display(Name = "ListLabelTraining", ResourceType = typeof(Resources.Team))]
        public TimeSpan TrainingTime1 { get; set; }

        public DayOfWeek? TrainingDay2 { get; set; }

        [TimeSpan]
        [Display(Name = "ListLabelTraining", ResourceType = typeof(Resources.Team))]
        public TimeSpan? TrainingTime2 { get; set; }
    }

    public sealed class AddTeamCommandHandler : ICommandHandler<AddTeamCommand>
    {
        private readonly IDataUnitOfWork uow;

        public AddTeamCommandHandler(IDataUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void Handle(AddTeamCommand command)
        {
            uow.Teams.AddObject(new Teams
            {
                Season = (int)command.Season,
                Category = (int)command.Category,
                Name = command.Name,
                TrainingDay1 = (int)command.TrainingDay1,
                TrainingTime1 = command.TrainingTime1,
                TrainingDay2 = (int?)command.TrainingDay2,
                TrainingTime2 = command.TrainingDay2 == null ? null : command.TrainingTime2
            });

            uow.SaveChanges();
        }
    }
}
