using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Routing;
using Data;

namespace TestPushNotification.Controllers
{
    public class TestNotificationController : ApiController
    {
        // GET: api/TestNotification
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TestNotification/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TestNotification
        public void Post([FromBody]Student value)
        {

            var context = new NotificationDBContext();

            var on = new UserNotification();
            on.ID = Guid.NewGuid();
            on.UserID = value.UserID;
            on.PlayerID = value.PlayerID;
            context.UserNotifications.Add(on);
            context.SaveChanges();

            var obj = new Notification();
            obj.Message = "You are: " + value.UserID;
            obj.UserID = value.UserID;
            obj.Url = "Test";
            context.Notifications.Add(obj);
            context.SaveChanges();
        }

        // PUT: api/TestNotification/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TestNotification/5
        public void Delete(int id)
        {
        }
    }

    public class Student
    {
        public string UserID { get; set; }
        public string PlayerID { get; set; }
    }
}
