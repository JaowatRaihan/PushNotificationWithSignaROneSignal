namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserNotifications",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        UserID = c.String(),
                        PlayerID = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AlterColumn("dbo.Notifications", "UserID", c => c.String());
            AlterColumn("dbo.Notifications", "StatusID", c => c.Int());
            AlterColumn("dbo.Notifications", "readDate", c => c.DateTime());
            AlterColumn("dbo.Notifications", "PostedBy", c => c.Int());
            AlterColumn("dbo.Notifications", "PostedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Notifications", "PostedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Notifications", "PostedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Notifications", "readDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Notifications", "StatusID", c => c.Int(nullable: false));
            AlterColumn("dbo.Notifications", "UserID", c => c.Int(nullable: false));
            DropTable("dbo.UserNotifications");
        }
    }
}
