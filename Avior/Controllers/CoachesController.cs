using System.Web.Mvc;
using Avior.Business.Code;

namespace Avior.Controllers
{
    public class CoachesController : AviorController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}