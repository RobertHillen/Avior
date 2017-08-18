using System.IO;
using System.Web.Mvc;
using Avior.Base.Enums;
using Avior.Business.Code;
using Avior.Helpers;
using Avior.Models.Log;
using Avior.Business.Helpers;
using log4net;

namespace Avior.Controllers
{
    public class LogController : AviorController
    {
        private readonly QueryExecutor _queryExecutor;
        private readonly LogHelper _logHelper;

        private readonly ILog logger = LogManager.GetLogger(typeof(LogController));

        public LogController(QueryExecutor queryExecutor, LogHelper logHelper)
        {
            _queryExecutor = queryExecutor;
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
                Files = _queryExecutor.GetLogFileHtmlSelectList(this, root, HtmlSelectOption.None),
                noInfoLevel = false
            };

            return model;
        }

        #endregion
    }
}