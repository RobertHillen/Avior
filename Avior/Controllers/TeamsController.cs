using System.Web.Mvc;
using log4net;
using Avior.Base.Enums;
using Avior.Base.Interfaces;
using Avior.Business.Code;
using Avior.Business.Commands.Team;
using Avior.Helpers;
using Avior.Models.Teams;

namespace Avior.Controllers
{
    public class TeamsController : AviorController
    {
        private readonly ICommandHandler<AddTeamCommand> _addTeamCommand;
        private readonly ICommandHandler<EditTeamCommand> _editTeamCommand;
        private readonly ICommandHandler<DeleteTeamCommand> _deleteTeamCommand;
        private readonly QueryExecutor _queryExecutor;

        private readonly ILog logger = LogManager.GetLogger(typeof(TeamsController));

        #region Constructor

        public TeamsController(
            ICommandHandler<AddTeamCommand> addTeamCommand,
            ICommandHandler<EditTeamCommand> editTeamCommand,
            ICommandHandler<DeleteTeamCommand> deleteTeamCommand,
            QueryExecutor queryExecutor)
        {
            _addTeamCommand = addTeamCommand;
            _editTeamCommand = editTeamCommand;
            _deleteTeamCommand = deleteTeamCommand;
            _queryExecutor = queryExecutor;
        }

        #endregion

        #region List

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            logger.Info("List");

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
                logger.InfoFormat("Edit Save {0}", command.ID);

                _editTeamCommand.Handle(command);
                return RedirectToAction("Index");
            }

            var model = GetEditData(command.ID);
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

                _deleteTeamCommand.Handle(new DeleteTeamCommand { ID = id });
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

        private TeamEditModel GetEditData(int Id)
        {
            var model = new TeamEditModel
            {
                Command = _queryExecutor.GetTeamEdit(this, Id)
            };

            return model;
        }

        private TeamListModel GetListData()
        {
            var model = new TeamListModel
            {
                TeamList = _queryExecutor.GetTeamList(this)
            };

            return model;
        }

        private TeamDetailModel GetDetailData(int Id)
        {
            var model = new TeamDetailModel
            {
                Details = _queryExecutor.GetTeamDetails(this, Id)
            };

            return model;
        }

        #endregion
    }
}
