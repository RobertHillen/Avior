using System.Net;
using System.Web.Mvc;
using Avior.Base.Enums;
using Avior.Base.Interfaces;
using Avior.Business.Code;
using Avior.Business.Commands.Coach;
using Avior.Database.Entity;
using Avior.Helpers;
using Avior.Models.Coaches;

namespace Avior.Controllers
{
    public class CoachesController : AviorController
    {
        private readonly ICommandHandler<EditCoachCommand> _editCoachCommand;
        private readonly QueryExecutor _queryExecutor;

        #region Constructor

        public CoachesController(
            ICommandHandler<EditCoachCommand> editCoachCommand,
            QueryExecutor queryExecutor)
        {
            _editCoachCommand = editCoachCommand;
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
            var model = GetListData();

            return View(model);
        }

        #endregion

        #region Details

        public ActionResult Details(int id)
        {
            var model = GetDetailData(id);

            return View(model);
        }

        #endregion

        #region Edit

        public ActionResult Edit(int id)
        {
            var model = GetEditData(id);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditCoachCommand command)
        {
            if (ModelState.IsValid)
            {
                _editCoachCommand.Handle(command);
                return RedirectToAction("Index");
            }

            var model = GetEditData(command.ID);
            model.Command = command;

            return View(model);
        }

        #endregion

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Coaches coach)
        {
            if (ModelState.IsValid)
            {
                //db.Coaches.Add(coach);
                //db.SaveChanges();
                return RedirectToAction("List");
            }

            return View(coach);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Coaches coach = db.Coaches.Find(id);
            //if (coach == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(coach);
            return View();
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            //Coaches coach = db.Coaches.Find(id);
            //db.Coaches.Remove(coach);
            //db.SaveChanges();

            return RedirectToAction("List");
        }

        #region Private helpers

        private CoachEditModel GetEditData(int Id)
        {
            var model = new CoachEditModel
            {
                Command = _queryExecutor.GetCoachEdit(this, Id),
                Teams = _queryExecutor.GetTeamHtmlSelectList(this,  HtmlSelectOption.FirstRow_DefaultText)
            };

            return model;
        }


        private CoachListModel GetListData()
        {
            var model = new CoachListModel
            {
                CoachList = _queryExecutor.GetCoachList(this)
            };

            return model;
        }

        private CoachDetailModel GetDetailData(int Id)
        {
            var model = new CoachDetailModel
            {
                Details = _queryExecutor.GetCoachDetails(this, Id)
            };

            return model;
        }

        #endregion
    }
}
