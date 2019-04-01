using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;

namespace TestPushNotification.Controllers
{
    public class NotificationsController : Controller
    {
        // GET: Home  
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetMessages()
        {
            var messages = new List<Notification>();
            var r = new Repository();
            r.GetAllMessages();
            return Json(messages, JsonRequestBehavior.AllowGet);
        }

    }
}
