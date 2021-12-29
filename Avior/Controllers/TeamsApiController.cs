using System.Linq;
using System.Web.Http;
using Avior.Base.Interfaces;
using Avior.Business.Commands.Team;
using Avior.Business.Helpers;
using Avior.Business.Queries.Team;
using Avior.Business.Views.Team;
using Avior.Models.Teams;
using log4net;

namespace Avior.Controllers
{
    [RoutePrefix("api/TeamsApi")]
    public class TeamsApiController : ApiController
    {
        private readonly IQueryHandler<GetTeamListQuery, IQueryable<TeamDetailView>> _listTeamQuery;
        private readonly IQueryHandler<GetTeamEditQuery, EditTeamCommand> _editTeamQuery;
        private readonly ICommandHandler<AddTeamCommand> _addTeamCommand;
        private readonly ICommandHandler<EditTeamCommand> _editTeamCommand;

        private readonly LogHelper _logHelper;
        private readonly ILog logger = LogManager.GetLogger(typeof(TeamsApiController));

        public TeamsApiController(
            IQueryHandler<GetTeamListQuery, IQueryable<TeamDetailView>> listTeamQuery,
            IQueryHandler<GetTeamEditQuery, EditTeamCommand> editTeamQuery,
            ICommandHandler<AddTeamCommand> addTeamCommand,
            ICommandHandler<EditTeamCommand> editTeamCommand,
            LogHelper logHelper)
        {
            _listTeamQuery = listTeamQuery;
            _editTeamQuery = editTeamQuery;
            _addTeamCommand = addTeamCommand;
            _editTeamCommand = editTeamCommand;
        _logHelper = logHelper;
        }

        [HttpPost()]
        [Route("GetList")]
        public IHttpActionResult GetTeamList()
        {
            logger.Info("GetList");

            var result = _listTeamQuery.Handle(new GetTeamListQuery() { });

            IHttpActionResult ret;

            if (result.Any())
            {
                ret = Ok(result.ToArray());
            }
            else
            {
                ret = NotFound();
            }

            return ret;
        }

        [HttpPost()]
        [Route("GetTeam")]
        public IHttpActionResult GetTeam([FromBody] TeamContentRequest Request)
        {
            logger.Info($"GetTeam ({Request.Id})");

            var team = _editTeamQuery.Handle(new GetTeamEditQuery() { Id = Request.Id });

            IHttpActionResult ret;

            if (team != null)
            {
                ret = Ok(team);
            }
            else
            {
                ret = NotFound();
            }

            return ret;
        }

        [HttpPost()]
        [Route("Add")]
        public IHttpActionResult AddTeam([FromBody] TeamUpdateRequestModel team)
        {
            if (team != null && team.Id == 0)
            {
                logger.Info($"AddTeam ({team.Name})");

                _addTeamCommand.Handle(new AddTeamCommand()
                {
                    Name = team.Name,
                    Season = team.Season,
                    Category = team.Category,
                    TrainingDay1 = team.TrainingDay1,
                    TrainingTime1 = team.TrainingTime1,
                    TrainingLocation1 = team.TrainingLocation1,
                    TrainingDay2 = team.TrainingDay2,
                    TrainingTime2 = team.TrainingTime2,
                    TrainingLocation2 = team.TrainingLocation2
                });
            }
            else
            {
                logger.Info("AddTeam: No data specified");
            }

            IHttpActionResult ret;
            if (team != null)
            {
                ret = Ok(true);
            }
            else
            {
                ret = NotFound();
            }

            return ret;
        }

        [HttpPost()]
        [Route("Edit")]
        public IHttpActionResult EditTeam([FromBody] TeamUpdateRequestModel team)
        {
            if (team != null)
            {
                logger.Info($"EditTeam ({team.Id})");

                _editTeamCommand.Handle(new EditTeamCommand()
                {
                    Id = team.Id,
                    Name = team.Name,
                    Season = team.Season,
                    Category = team.Category,
                    TrainingDay1 = team.TrainingDay1,
                    TrainingTime1 = team.TrainingTime1,
                    TrainingLocation1 = team.TrainingLocation1,
                    TrainingDay2 = team.TrainingDay2,
                    TrainingTime2 = team.TrainingTime2,
                    TrainingLocation2 = team.TrainingLocation2
                });
            }
            else
            {
                logger.Info("EditTeam: No data specified");
            }

            IHttpActionResult ret;
            if (team != null)
            {
                ret = Ok(true);
            }
            else
            {
                ret = NotFound();
            }

            return ret;
        }
    }
}
