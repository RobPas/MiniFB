namespace MiniFB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Password = c.String(),
                        Salt = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                        UserName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Sex = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.NewsFeedItems",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        UserID = c.Guid(nullable: false),
                        Type = c.String(nullable: false),
                        Content = c.String(maxLength: 250),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        NewsFeed_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.NewsFeeds", t => t.NewsFeed_ID)
                .Index(t => t.UserID)
                .Index(t => t.NewsFeed_ID);
            
           CreateTable(
                "dbo.NewsFeedComments",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        UserID = c.Guid(nullable: false),
                        Message = c.String(),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        NewsFeedItem_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.NewsFeedItems", t => t.NewsFeedItem_ID)
                .Index(t => t.UserID)
                .Index(t => t.NewsFeedItem_ID);
            
            CreateTable(
                "dbo.NewsFeeds",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        UserID = c.Guid(nullable: false),
                        OrderBy = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.NewsFeeds", new[] { "UserID" });
            DropIndex("dbo.NewsFeedComments", new[] { "NewsFeedItem_ID" });
            DropIndex("dbo.NewsFeedComments", new[] { "UserID" });
            DropIndex("dbo.NewsFeedItems", new[] { "NewsFeed_ID" });
            DropIndex("dbo.NewsFeedItems", new[] { "UserID" });
            DropForeignKey("dbo.NewsFeeds", "UserID", "dbo.Users");
            DropForeignKey("dbo.NewsFeedComments", "NewsFeedItem_ID", "dbo.NewsFeedItems");
            DropForeignKey("dbo.NewsFeedComments", "UserID", "dbo.Users");
            DropForeignKey("dbo.NewsFeedItems", "NewsFeed_ID", "dbo.NewsFeeds");
            DropForeignKey("dbo.NewsFeedItems", "UserID", "dbo.Users");
            DropTable("dbo.NewsFeeds");
            DropTable("dbo.NewsFeedComments");
            DropTable("dbo.NewsFeedItems");
            DropTable("dbo.Users");
        }
    }
}
