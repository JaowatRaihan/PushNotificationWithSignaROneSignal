using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using Notification = OneSignal.Template.Templates.Notification;

namespace TestPushNotification.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Notification myNotification = new Notification();
            //myNotification.contents = "d";
            //myNotification.small_icon = "icon.png";
            //myNotification.include_player_ids = new List<string> { "e610656f-ac88-4183-b238-3935024c6e39", "b705ded4-1646-48c2-b8af-302311567eca", "46d0f7ce-3d67-487c-8bab-6ca392bc4d4c", "820c96f9-9208-4d2d-9cfd-6f5022b7d0b2" };
            //myNotification.url = "d1";
            //myNotification.Send();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}