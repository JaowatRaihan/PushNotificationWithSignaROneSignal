using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Data;
using Microsoft.AspNet.SignalR;
using Notification = OneSignal.Template.Templates.Notification;

namespace TestPushNotification
{
    public class Repository
    {
        SqlConnection co = new SqlConnection(System.Web.Configuration.WebConfigurationManager
            .ConnectionStrings["NotificationDbContext1"].ConnectionString);

        public void GetAllMessages()
        {
        

            //var messages = new List<Notification>();
            //SqlDependency.Start("NotificationDbContext");
            //using (var cmd = new SqlCommand(@"SELECT [ID],[UserID],   
            //    [Message],[Url],[StatusID],[readDate],[PostedBy],[PostedDate] FROM [dbo].[Notifications]", co))
            //{
            //    SqlDataAdapter da = new SqlDataAdapter(cmd);
            //    var dependency = new SqlDependency(cmd);
            //    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);
            //    DataSet ds = new DataSet();
            //    da.Fill(ds);
            //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //    {
            //        messages.Add(item: new Notification
            //        {
            //            ID = int.Parse(ds.Tables[0].Rows[i][0].ToString()),
            //            UserID = int.Parse(ds.Tables[0].Rows[i][1].ToString()),
            //            Message = ds.Tables[0].Rows[i][2].ToString(),
            //            Url = ds.Tables[0].Rows[i][3].ToString(),
            //            StatusID = int.Parse(ds.Tables[0].Rows[i][4].ToString()),
            //            readDate = Convert.ToDateTime(ds.Tables[0].Rows[i][5].ToString()),
            //            PostedBy = int.Parse(ds.Tables[0].Rows[i][6].ToString()),
            //            PostedDate = Convert.ToDateTime(ds.Tables[0].Rows[i][7].ToString())
            //        });
            //    }
            //}

            string connectionString = ConfigurationManager.ConnectionStrings["NotificationDbContext1"].ConnectionString;

            string sql = @"select [UserID] from [dbo].[Notifications]";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                //cmd.Parameters.AddWithValue("@UserID", userId);
                //cmd.Parameters.AddWithValue("@uid", uid);
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }

                cmd.Notification = null;
                SqlDependency dependency = new SqlDependency(cmd);
                dependency.OnChange += dependency_OnChange;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    //nothing
                }
            }
        }

         private async void
            dependency_OnChange(object sender,
                SqlNotificationEventArgs e) //this will be called when any changes occur in db table. 
        {
            
             try
            {
                if (e.Type == SqlNotificationType.Change)
                {
                    SqlDependency sqlDependency = sender as SqlDependency;
                    if (sqlDependency == null)
                        return;

                    sqlDependency.OnChange -= dependency_OnChange;
                    var notificationHub = GlobalHost.ConnectionManager.GetHubContext<MyHub>();

                    if (e.Info == SqlNotificationInfo.Insert)
                    {
                        notificationHub.Clients.All.notify("added");

                        var context = new NotificationDBContext();

                        var user = context.Notifications.FirstOrDefault();

                        var map = context.UserNotifications.Where(x => x.UserID == user.UserID).Select(x => x.PlayerID).ToList();

                        Notification myNotification = new Notification();
                        myNotification.contents = user.Message;
                        myNotification.small_icon = "icon.png";
                        myNotification.include_player_ids = map;
                        myNotification.url = "";
                        myNotification.Send();
                    }


                    GetAllMessages();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}