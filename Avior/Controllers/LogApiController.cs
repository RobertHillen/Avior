using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web.Http;
using Avior.Base.Enums;
using Avior.Base.Interfaces;
using Avior.Business.Helpers;
using Avior.Business.Queries.Log;
using Avior.Business.Views.Log;
using Avior.Models.Log;
using log4net;

namespace Avior.Controllers
{
    [RoutePrefix("api/LogApi")]
    public class LogApiController : ApiController
    {
        private readonly IQueryHandler<GetLogFileHtmlSelectQuery, LogFileHtmlSelectView[]> _htmllogfileHtmlselectTeamQuery;
        private readonly LogHelper _logHelper;
        private readonly ILog logger = LogManager.GetLogger(typeof(LogApiController));

        public LogApiController(
            IQueryHandler<GetLogFileHtmlSelectQuery, LogFileHtmlSelectView[]> htmllogfileHtmlselectTeamQuery,
            LogHelper logHelper)
        {
            _htmllogfileHtmlselectTeamQuery = htmllogfileHtmlselectTeamQuery;
            _logHelper = logHelper;
        }

        [HttpPost()]
        [Route("FileList")]
        public IHttpActionResult GetFileList()
        {
            logger.Info($"GetFileList");

            var root = ConfigurationManager.AppSettings["LogPath"].ToString();
            var Files = _htmllogfileHtmlselectTeamQuery.Handle(new GetLogFileHtmlSelectQuery { Root = root, HtmlSelectOption = HtmlSelectOption.None });

            IHttpActionResult ret;

            if (Files.Any())
            {
                List<string> filelist = new List<string>();
                foreach (var item in Files)
                {
                    filelist.Add(item.Key);
                }

                ret = Ok(filelist.ToArray());
            }
            else
            {
                ret = NotFound();
            }

            return ret;
        }

        [HttpPost()]
        [Route("Content")]
        public IHttpActionResult GetContent([FromBody] LogContentRequest request)
        {
            logger.Info($"GetContent {request.fileName} ({request.noInfo})");

            var root = ConfigurationManager.AppSettings["LogPath"].ToString();
            var fullname = Path.Combine(root, request.fileName);

            var content = _logHelper.processLog(fullname, request.noInfo);

            IHttpActionResult ret;
            
            if (content.Any())
            {
                ret = Ok(content.ToArray());
            }
            else
            {
                ret = NotFound();
            }

            return ret;
        }
    }
}
