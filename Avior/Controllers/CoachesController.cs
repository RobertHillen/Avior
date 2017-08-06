using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Avior.Database.Data;
using Avior.Database.Models;
using Avior.Models.Coaches;
using Avior.Helpers;
using Avior.Business.Code;
using Avior.Base.Interfaces;
using Avior.Business.Commands.Coach;
using Avior.Base.Enums;

namespace Avior.Controllers
{
    public class CoachesController : AviorController
    {
        private readonly ICommandHandler<EditCoachCommand> _editCoachCommand;
        private readonly QueryExecutor _queryExecutor;
        private AviorDbContext db = new AviorDbContext();

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
        public ActionResult Create(Coach coach)
        {
            if (ModelState.IsValid)
            {
                db.Coaches.Add(coach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coach);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coach coach = db.Coaches.Find(id);
            if (coach == null)
            {
                return HttpNotFound();
            }
            return View(coach);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Coach coach = db.Coaches.Find(id);
            db.Coaches.Remove(coach);
            db.SaveChanges();
            return RedirectToAction("Index");
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
