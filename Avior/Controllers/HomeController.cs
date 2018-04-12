using Avior.Business.Code;
using System.Web.Mvc;

namespace Avior.Controllers
{
    public class HomeController : AviorController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}