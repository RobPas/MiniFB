namespace MiniFB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NewsFeedComments", "UserID", "dbo.Users");
            DropIndex("dbo.NewsFeedComments", new[] { "UserID" });
            AddColumn("dbo.NewsFeedComments", "NewsFeedItemGuid", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NewsFeedComments", "NewsFeedItemGuid");
            CreateIndex("dbo.NewsFeedComments", "UserID");
            AddForeignKey("dbo.NewsFeedComments", "UserID", "dbo.Users", "ID", cascadeDelete: true);
        }
    }
}
