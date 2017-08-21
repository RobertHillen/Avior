using System;
using System.ComponentModel.DataAnnotations;
using Avior.Base.Enums;
using Avior.Base.Interfaces;
using Avior.Business.Attributes;
using Avior.Business.UnitOfWork;
using Avior.Business.UnitOfWork.Extensions;

namespace Avior.Business.Commands.Team
{
    public class EditTeamCommand
    {
        [Required]
        public int ID { get; set; }

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

    public sealed class EditTeamCommandHandler : ICommandHandler<EditTeamCommand>
    {
        private readonly IDataUnitOfWork uow;

        public EditTeamCommandHandler(IDataUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void Handle(EditTeamCommand command)
        {
            var team = uow.Teams.GetById(command.ID);

            team.Season = (int)command.Season;
            team.Category = (int)command.Category;
            team.Name = command.Name;
            team.TrainingDay1 = (int)command.TrainingDay1;
            team.TrainingTime1 = command.TrainingTime1;
            team.TrainingDay2 = (int?)command.TrainingDay2;
            team.TrainingTime2 = command.TrainingDay2 == null ? null : command.TrainingTime2;

            uow.SaveChanges();
        }
    }
}