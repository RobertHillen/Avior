using Avior.Business.Helpers;
using log4net;
using System.Configuration;
using System.Linq;
using System.Web.Http;

namespace Avior.Controllers
{
    [RoutePrefix("api/AboutApi")]
    public class AboutApiController : ApiController
    {
        private readonly LogHelper _logHelper;
        private readonly ILog logger = LogManager.GetLogger(typeof(AboutApiController));

        public AboutApiController(LogHelper logHelper)
        {
            _logHelper = logHelper;
        }

        [HttpPost()]
        [Route("PackagesList")]
        public IHttpActionResult GetPackagesList()
        {
            logger.Info($"GetPackagesList");

            var root = ConfigurationManager.AppSettings["RootPath"].ToString();
            var packageList = _logHelper.ProcessPackagesConfig(root);

            IHttpActionResult ret;

            if (packageList.Any())
            {
                ret = Ok(packageList);
            }
            else
            {
                ret = NotFound();
            }

            return ret;
        }
    }
}