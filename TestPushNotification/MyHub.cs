using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace TestPushNotification
{
    public class MyHub : Hub
    {
        //public static void Announce(string msg)
        //{
        //    IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
        //    context.Clients.All.Announce();
        //}
    }
}