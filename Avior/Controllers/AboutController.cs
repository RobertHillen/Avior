using Avior.Business.Code;
using System.Web.Mvc;

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