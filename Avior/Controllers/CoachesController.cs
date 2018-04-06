using System.Linq;
using System.Web.Mvc;
using Avior.Base.Enums;
using Avior.Base.Interfaces;
using Avior.Business.Code;
using Avior.Business.Commands.Coach;
using Avior.Business.Queries.Coach;
using Avior.Business.Queries.Team;
using Avior.Business.Views.Coach;
using Avior.Business.Views.Team;
using Avior.Models.Coaches;
using log4net;

namespace Avior.Controllers
{
    public class CoachesController : AviorController
    {
        private readonly IQueryHandler<GetCoachEditQuery, EditCoachCommand> _editCoachQuery;
        private readonly IQueryHandler<GetCoachListQuery, IQueryable<CoachDetailView>> _listCoachQuery;
        private readonly IQueryHandler<GetCoachDetailsQuery, CoachDetailView> _detailCoachQuery;
        private readonly IQueryHandler<GetTeamHtmlSelectQuery, TeamHtmlSelectView[]> _htmlselectTeamQuery;

        private readonly ICommandHandler<AddCoachCommand> _addCoachCommand;
        private readonly ICommandHandler<EditCoachCommand> _editCoachCommand;
        private readonly ICommandHandler<DeleteCoachCommand> _deleteCoachCommand;

        private readonly ILog logger = LogManager.GetLogger(typeof(CoachesController));

        #region Constructor

        public CoachesController(
            IQueryHandler<GetCoachEditQuery, EditCoachCommand> editCoachQuery,
            IQueryHandler<GetCoachListQuery, IQueryable<CoachDetailView>> listCoachQuery,
            IQueryHandler<GetCoachDetailsQuery, CoachDetailView> detailCoachQuery,
            IQueryHandler<GetTeamHtmlSelectQuery, TeamHtmlSelectView[]> htmlselectTeamQuery,
            ICommandHandler<AddCoachCommand> addCoachCommand,
            ICommandHandler<EditCoachCommand> editCoachCommand,
            ICommandHandler<DeleteCoachCommand> deleteCoachCommand)
        {
            _editCoachQuery = editCoachQuery;
            _listCoachQuery = listCoachQuery;
            _detailCoachQuery = detailCoachQuery;
            _htmlselectTeamQuery = htmlselectTeamQuery;
            _addCoachCommand = addCoachCommand;
            _editCoachCommand = editCoachCommand;
            _deleteCoachCommand = deleteCoachCommand;
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
        public ActionResult Add(AddCoachCommand command)
        {
            if (ModelState.IsValid)
            {
                logger.InfoFormat("Add Save {0}", command.Name);

                _addCoachCommand.Handle(command);
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
        public ActionResult Edit(EditCoachCommand command)
        {
            if (ModelState.IsValid)
            {
                logger.InfoFormat("Edit Save {0}", command.ID);

                _editCoachCommand.Handle(command);
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

            _deleteCoachCommand.Handle(new DeleteCoachCommand { ID = id });

            return RedirectToAction("List");
        }

        #endregion

        #region Private helpers

        private CoachAddModel GetAddData()
        {
            var model = new CoachAddModel
            {
                Command = new AddCoachCommand(),
                Teams = _htmlselectTeamQuery.Handle(new GetTeamHtmlSelectQuery() { HtmlSelectOption = HtmlSelectOption.None })
            };

            return model;
        }

        private CoachEditModel GetEditData(int id)
        {
            var model = new CoachEditModel
            {
                Command = _editCoachQuery.Handle(new GetCoachEditQuery() { Id = id }),
                Teams = _htmlselectTeamQuery.Handle(new GetTeamHtmlSelectQuery() { HtmlSelectOption = HtmlSelectOption.FirstRow_DefaultText })
            };

            return model;
        }

        private CoachListModel GetListData()
        {
            var model = new CoachListModel
            {
                CoachList = _listCoachQuery.Handle(new GetCoachListQuery() { })
            };

            return model;
        }

        private CoachDetailModel GetDetailData(int Id)
        {
            var model = new CoachDetailModel
            {
                Details = _detailCoachQuery.Handle(new GetCoachDetailsQuery() { ID = Id })
            };

            return model;
        }

        #endregion
    }
}
