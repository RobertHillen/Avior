using System.Web.Mvc;
using Avior.Business.Code;

namespace Avior.Controllers
{
    public class LogController : AviorController
    {
        public LogController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}