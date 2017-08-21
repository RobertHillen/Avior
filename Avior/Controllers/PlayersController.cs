using System.Web.Mvc;
using log4net;
using Avior.Base.Enums;
using Avior.Base.Interfaces;
using Avior.Business.Code;
using Avior.Business.Commands.Player;
using Avior.Helpers;
using Avior.Models.Players;

namespace Avior.Controllers
{
    public class PlayersController : AviorController
    {
        private readonly ICommandHandler<AddPlayerCommand> _addPlayerCommand;
        private readonly ICommandHandler<EditPlayerCommand> _editPlayerCommand;
        private readonly ICommandHandler<DeletePlayerCommand> _deletePlayerCommand;
        private readonly QueryExecutor _queryExecutor;

        private readonly ILog logger = LogManager.GetLogger(typeof(PlayersController));

        #region Constructor

        public PlayersController(
            ICommandHandler<AddPlayerCommand> addPlayerCommand,
            ICommandHandler<EditPlayerCommand> editPlayerCommand,
            ICommandHandler<DeletePlayerCommand> deletePlayerCommand,
            QueryExecutor queryExecutor)
        {
            _addPlayerCommand = addPlayerCommand;
            _editPlayerCommand = editPlayerCommand;
            _deletePlayerCommand = deletePlayerCommand;
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
        public ActionResult Add(AddPlayerCommand command)
        {
            if (ModelState.IsValid)
            {
                logger.InfoFormat("Add Save {0}", command.Name);

                _addPlayerCommand.Handle(command);
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
        public ActionResult Edit(EditPlayerCommand command)
        {
            if (ModelState.IsValid)
            {
                logger.InfoFormat("Edit Save {0}", command.ID);

                _editPlayerCommand.Handle(command);
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
        public ActionResult DeleteConfirmed(int id)
        {
            logger.InfoFormat("Deleted Id: {0}", id);

            _deletePlayerCommand.Handle(new DeletePlayerCommand { ID = id });

            return RedirectToAction("List");
        }

        #endregion

        #region Private helpers

        private PlayerAddModel GetAddData()
        {
            var model = new PlayerAddModel
            {
                Command = new AddPlayerCommand(),
                Teams = _queryExecutor.GetTeamHtmlSelectList(this, HtmlSelectOption.None)
            };

            return model;
        }

        private PlayerEditModel GetEditData(int Id)
        {
            var model = new PlayerEditModel
            {
                Command = _queryExecutor.GetPlayerEdit(this, Id),
                Teams = _queryExecutor.GetTeamHtmlSelectList(this, HtmlSelectOption.FirstRow_DefaultText)
            };

            return model;
        }

        private PlayerListModel GetListData()
        {
            var model = new PlayerListModel
            {
                PlayerList = _queryExecutor.GetPlayerList(this)
            };

            return model;
        }

        private PlayerDetailModel GetDetailData(int Id)
        {
            var model = new PlayerDetailModel
            {
                Details = _queryExecutor.GetPlayerDetails(this, Id)
            };

            return model;
        }

        #endregion
    }
}
