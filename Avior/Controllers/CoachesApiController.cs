using System;
using System.Linq;
using System.Web.Http;
using Avior.Base.Interfaces;
using Avior.Business.Commands.Coach;
using Avior.Business.Helpers;
using Avior.Business.Queries.Coach;
using Avior.Business.Views.Coach;
using Avior.Models.Coaches;
using log4net;

namespace Avior.Controllers
{
    [RoutePrefix("api/CoachesApi")]
    public class CoachesApiController : ApiController
    {
        private readonly IQueryHandler<GetCoachListQuery, IQueryable<CoachDetailView>> _listCoachQuery;
        private readonly IQueryHandler<GetCoachEditQuery, EditCoachCommand> _editCoachQuery;
        private readonly IQueryHandler<GetCoachDetailsQuery, CoachDetailView> _detailCoachQuery;
        private readonly ICommandHandler<AddCoachCommand> _addCoachCommand;
        private readonly ICommandHandler<EditCoachCommand> _editCoachCommand;
        private readonly ICommandHandler<DeleteCoachCommand> _deleteCoachCommand;

        private readonly LogHelper _logHelper;
        private readonly ILog logger = LogManager.GetLogger(typeof(CoachesApiController));

        public CoachesApiController(
            IQueryHandler<GetCoachListQuery, IQueryable<CoachDetailView>> listCoachQuery,
            IQueryHandler<GetCoachEditQuery, EditCoachCommand> editCoachQuery,
            IQueryHandler<GetCoachDetailsQuery, CoachDetailView> detailCoachQuery,
            ICommandHandler<AddCoachCommand> addCoachCommand,
            ICommandHandler<EditCoachCommand> editCoachCommand,
            ICommandHandler<DeleteCoachCommand> deleteCoachCommand,
            LogHelper logHelper)
        {
            _listCoachQuery = listCoachQuery;
            _editCoachQuery = editCoachQuery;
            _detailCoachQuery = detailCoachQuery;
            _addCoachCommand = addCoachCommand;
            _editCoachCommand = editCoachCommand;
            _deleteCoachCommand = deleteCoachCommand;
            _logHelper = logHelper;
        }

        [HttpPost()]
        [Route("List")]
        public IHttpActionResult GetCoachList()
        {
            logger.Info("GetCoachList");

            var list = _listCoachQuery.Handle(new GetCoachListQuery() { });

            IHttpActionResult ret;
            if (list.Any())
            {
                ret = Ok(list.ToArray());
            }
            else
            {
                ret = NotFound();
            }

            return ret;
        }

        [HttpPost()]
        [Route("Get")]
        public IHttpActionResult GetCoach([FromBody] CoachContentRequestModel Request)
        {   
            logger.Info($"GetCoach ({Request.Id})");

            var coach = _editCoachQuery.Handle(new GetCoachEditQuery() { Id = Request.Id });

            IHttpActionResult ret;
            if (coach != null)
            {
                ret = Ok(coach);
            }
            else
            {
                ret = NotFound();
            }

            return ret;
        }

        [HttpPost()]
        [Route("Add")]
        public IHttpActionResult AddCoach([FromBody] CoachUpdateRequestModel coach)
        {
            if (coach != null && coach.Id == 0)
            {
                logger.Info($"AddCoach ({coach.Name})");

                _addCoachCommand.Handle(new AddCoachCommand()
                {
                    Name = coach.Name,
                    PhoneNumber = coach.PhoneNumber,
                    Email = coach.Email,
                    TeamId = coach.TeamId
                });
            }
            else
            {
                logger.Info("AddCoach: No data specified");
            }

            IHttpActionResult ret;
            if (coach != null)
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
        public IHttpActionResult EditCoach([FromBody] CoachUpdateRequestModel coach)
        {
            if (coach != null)
            {
                logger.Info($"EditCoach ({coach.Id})");

                _editCoachCommand.Handle(new EditCoachCommand()
                {
                    Id = coach.Id,
                    Name = coach.Name,
                    PhoneNumber = coach.PhoneNumber,
                    Email = coach.Email,
                    TeamId = coach.TeamId
                });
            }
            else
            {
                logger.Info("EditCoach: No data specified");
            }

            IHttpActionResult ret;
            if (coach != null)
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
        [Route("Delete")]
        public IHttpActionResult DeleteCoach([FromBody] CoachContentRequestModel Request)
        {
            logger.Info($"DeleteCoach ({Request.Id})");

            _deleteCoachCommand.Handle(new DeleteCoachCommand() { Id = Request.Id });

            IHttpActionResult ret = Ok(true);

            return ret;
        }

        [HttpPost()]
        [Route("Details")]
        public IHttpActionResult GetCoachDetails([FromBody] CoachContentRequestModel Request)
        {
            logger.Info($"GetCoachDetails ({Request.Id})");

            var coach = _detailCoachQuery.Handle(new GetCoachDetailsQuery () { Id = Request.Id });

            IHttpActionResult ret;
            if (coach != null)
            {
                ret = Ok(coach);
            }
            else
            {
                ret = NotFound();
            }

            return ret;
        }
    }
}
