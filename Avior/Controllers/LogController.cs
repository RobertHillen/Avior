using System.IO;
using System.Web.Mvc;
using log4net;
using Avior.Base.Enums;
using Avior.Business.Code;
using Avior.Models.Log;
using Avior.Business.Helpers;
using Avior.Base.Interfaces;
using Avior.Business.Queries.Log;
using Avior.Business.Views.Log;

namespace Avior.Controllers
{
    public class LogController : AviorController
    {
        private readonly IQueryHandler<GetLogFileHtmlSelectQuery, LogFileHtmlSelectView[]> _htmllogfileHtmlselectTeamQuery;

        private readonly LogHelper _logHelper;

        private readonly ILog logger = LogManager.GetLogger(typeof(LogController));

        public LogController(
            IQueryHandler<GetLogFileHtmlSelectQuery, LogFileHtmlSelectView[]> htmllogfileHtmlselectTeamQuery,
            LogHelper logHelper)
        {
            _htmllogfileHtmlselectTeamQuery = htmllogfileHtmlselectTeamQuery;
            _logHelper = logHelper;
        }

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

        public ActionResult GetContent(string fileName, bool noInfo)
        {
            logger.InfoFormat("GetContent {0} ({1})", fileName, noInfo);

            var fullname = Path.Combine(Server.MapPath(@"~\logs"), fileName);

            var model = new LogContentModel
            {
                log = _logHelper.processLog(fullname, noInfo)
            };

            return PartialView("LogContent", model);
        }

        #endregion

        #region Private helpers

        private LogListModel GetListData()
        {
            var root = Server.MapPath(@"~\logs");

            var model = new LogListModel
            {
                Root = root,
                Files = _htmllogfileHtmlselectTeamQuery.Handle(new GetLogFileHtmlSelectQuery { Root = root, HtmlSelectOption = HtmlSelectOption.None }),
                noInfoLevel = false
            };

            return model;
        }

        #endregion
    }
}