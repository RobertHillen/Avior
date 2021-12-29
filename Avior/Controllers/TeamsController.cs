using System.Linq;
using System.Web.Mvc;
using log4net;
using Avior.Base.Enums;
using Avior.Base.Interfaces;
using Avior.Business.Code;
using Avior.Business.Commands.Team;
using Avior.Models.Teams;
using Avior.Business.Commands.Player;
using Avior.Business.Queries.Team;
using Avior.Business.Views.Team;

namespace Avior.Controllers
{
    public class TeamsController : AviorController
    {
        IQueryHandler<GetTeamEditQuery, EditTeamCommand> _editTeamQuery;
        IQueryHandler<GetTeamListQuery, IQueryable<TeamDetailView>> _listTeamQuery;
        IQueryHandler<GetTeamDetailsQuery, TeamDetailView> _detailTeamQuery;

        private readonly ICommandHandler<AddTeamCommand> _addTeamCommand;
        private readonly ICommandHandler<EditTeamCommand> _editTeamCommand;
        private readonly ICommandHandler<DeleteTeamCommand> _deleteTeamCommand;

        private readonly ILog logger = LogManager.GetLogger(typeof(TeamsController));

        #region Constructor

        public TeamsController(
            IQueryHandler<GetTeamEditQuery, EditTeamCommand> editTeamQuery,
            IQueryHandler<GetTeamListQuery, IQueryable<TeamDetailView>> listTeamQuery,
            IQueryHandler<GetTeamDetailsQuery, TeamDetailView> detailTeamQuery,
            ICommandHandler<AddTeamCommand> addTeamCommand,
            ICommandHandler<EditTeamCommand> editTeamCommand,
            ICommandHandler<DeleteTeamCommand> deleteTeamCommand)
        {
            _editTeamQuery = editTeamQuery;
            _listTeamQuery = listTeamQuery;
            _detailTeamQuery = detailTeamQuery;

            _addTeamCommand = addTeamCommand;
            _editTeamCommand = editTeamCommand;
            _deleteTeamCommand = deleteTeamCommand;
        }

        #endregion

        #region List

        public ActionResult Index()
        {
            logger.Info("Index");

            var model = GetListData();

            return View(model);
        }

        #endregion

        #region Details

        public ActionResult Details(int id)
        {
            logger.InfoFormat("Details Id: {0}", id);

            var model = GetDetailData(id);

            return View(model);
        }

        #endregion

        #region Add

        public ActionResult Add()
        {
            logger.Info("Add");

            var model = GetAddData();

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(AddTeamCommand command)
        {
            if (ModelState.IsValid)
            {
                logger.InfoFormat("Add Save {0}", command.Name);

                _addTeamCommand.Handle(command);
                return RedirectToAction("Index");
            }

            var model = GetAddData();
            model.Command = command;
            return View(model);
        }

        #endregion

        #region Edit

        public ActionResult Edit(int id)
        {
            logger.InfoFormat("Edit Id: {0}", id);

            var model = GetEditData(id);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditTeamCommand command)
        {
            if (ModelState.IsValid)
            {
                logger.InfoFormat("Edit Save {0}", command.Id);

                _editTeamCommand.Handle(command);
                return RedirectToAction("Index");
            }

            var model = GetEditData(command.Id);
            model.Command = command;

            return View(model);
        }

        #endregion

        #region Delete

        public ActionResult Delete(int id)
        {
            logger.InfoFormat("Delete Id: {0} ?", id);

            var model = GetDetailData(id);

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id, bool hasCoachesPlayers)
        {
            if (!hasCoachesPlayers)
            {
                logger.InfoFormat("Deleted Id: {0}", id);

                _deleteTeamCommand.Handle(new DeleteTeamCommand { Id = id });
            }

            return RedirectToAction("List");
        }

        #endregion

        #region Private helpers

        private TeamAddModel GetAddData()
        {
            var model = new TeamAddModel
            {
                Command = new AddTeamCommand()
                {
                    Season = enuSeason.s2017_2018,
                    Category = enuCategory.CMV
                }
            };

            return model;
        }

        private TeamEditModel GetEditData(int id)
        {
            var model = new TeamEditModel
            {
                Command = _editTeamQuery.Handle(new GetTeamEditQuery() { Id = id }),
            };

            return model;
        }

        private TeamListModel GetListData()
        {
            var model = new TeamListModel
            {
                TeamList = _listTeamQuery.Handle(new GetTeamListQuery() { })
            };

            return model;
        }

        private TeamDetailModel GetDetailData(int Id)
        {
            var model = new TeamDetailModel
            {
                Details = _detailTeamQuery.Handle(new GetTeamDetailsQuery() { Id = Id })
            };

            return model;
        }

        #endregion
    }
}
