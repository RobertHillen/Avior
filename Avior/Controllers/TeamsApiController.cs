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
        private readonly IQueryHandler<GetTeamEditQuery, EditTeamCommand> _editTeamCommand;

        private readonly LogHelper _logHelper;
        private readonly ILog logger = LogManager.GetLogger(typeof(TeamsApiController));

        public TeamsApiController(
            IQueryHandler<GetTeamListQuery, IQueryable<TeamDetailView>> listTeamQuery,
            IQueryHandler<GetTeamEditQuery, EditTeamCommand> editTeamCommand,
            LogHelper logHelper)
        {
            _listTeamQuery = listTeamQuery;
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

            var team = _editTeamCommand.Handle(new GetTeamEditQuery() { Id = Request.Id });

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
    }
}
