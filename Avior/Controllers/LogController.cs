using System.Web.Mvc;
using Avior.Business.Code;

namespace Avior.Controllers
{
    public class LogController : AviorController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}