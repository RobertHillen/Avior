using System.Web.Mvc;
using Avior.Business.Code;

namespace Avior.Controllers
{
    public class AboutController : AviorController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}