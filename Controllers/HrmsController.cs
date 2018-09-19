using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DasBuildingWeb.Controllers
{
    public class HrmsController : Controller
    {
        // GET: Hrms
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UploadHrms()
        {
            return Content("");
        }
    }
}