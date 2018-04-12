using Avior.Business.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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