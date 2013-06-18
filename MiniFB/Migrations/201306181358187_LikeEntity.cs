namespace MiniFB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LikeEntity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "NewsFeedItem_ID", "dbo.NewsFeedItems");
            DropForeignKey("dbo.NewsFeedItems", "User_ID", "dbo.Users");
            DropIndex("dbo.Users", new[] { "NewsFeedItem_ID" });
            DropIndex("dbo.NewsFeedItems", new[] { "User_ID" });
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        UserID = c.Guid(nullable: false),
                        NewsFeedItemID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.NewsFeedItems", t => t.NewsFeedItemID, cascadeDelete: true)
                .Index(t => t.NewsFeedItemID);
            
            DropColumn("dbo.Users", "NewsFeedItem_ID");
            DropColumn("dbo.NewsFeedItems", "User_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NewsFeedItems", "User_ID", c => c.Guid());
            AddColumn("dbo.Users", "NewsFeedItem_ID", c => c.Guid());
            DropIndex("dbo.Likes", new[] { "NewsFeedItemID" });
            DropForeignKey("dbo.Likes", "NewsFeedItemID", "dbo.NewsFeedItems");
            DropTable("dbo.Likes");
            CreateIndex("dbo.NewsFeedItems", "User_ID");
            CreateIndex("dbo.Users", "NewsFeedItem_ID");
            AddForeignKey("dbo.NewsFeedItems", "User_ID", "dbo.Users", "ID");
            AddForeignKey("dbo.Users", "NewsFeedItem_ID", "dbo.NewsFeedItems", "ID");
        }
    }
}
