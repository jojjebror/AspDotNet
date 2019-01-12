namespace Taharifran.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Acceptedonfriendrequest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FriendRequests", "Accepted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FriendRequests", "Accepted");
        }
    }
}
