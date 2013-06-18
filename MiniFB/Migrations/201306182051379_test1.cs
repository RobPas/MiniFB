namespace MiniFB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
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
                        ConfirmationToken = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                        IsConfirmed = c.Boolean(nullable: false),
                        UserSecretQuestion = c.String(),
                        UserSecretAnswer = c.String(),
                        UserName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        IsUsingGravatar = c.Boolean(nullable: false),
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
                        ItemType = c.Int(nullable: false),
                        Data = c.String(),
                        Content = c.String(nullable: false, maxLength: 250),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
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
            
            CreateTable(
                "dbo.NewsFeedComments",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        CommentWriter = c.String(),
                        NewsFeedItemGuid = c.Guid(nullable: false),
                        Message = c.String(),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        NewsFeedItem_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.NewsFeedItems", t => t.NewsFeedItem_ID)
                .Index(t => t.NewsFeedItem_ID);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        FileName = c.String(),
                        FileType = c.String(),
                        UserID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Images", new[] { "UserID" });
            DropIndex("dbo.NewsFeedComments", new[] { "NewsFeedItem_ID" });
            DropIndex("dbo.Likes", new[] { "NewsFeedItemID" });
            DropIndex("dbo.NewsFeedItems", new[] { "UserID" });
            DropForeignKey("dbo.Images", "UserID", "dbo.Users");
            DropForeignKey("dbo.NewsFeedComments", "NewsFeedItem_ID", "dbo.NewsFeedItems");
            DropForeignKey("dbo.Likes", "NewsFeedItemID", "dbo.NewsFeedItems");
            DropForeignKey("dbo.NewsFeedItems", "UserID", "dbo.Users");
            DropTable("dbo.Images");
            DropTable("dbo.NewsFeedComments");
            DropTable("dbo.Likes");
            DropTable("dbo.NewsFeedItems");
            DropTable("dbo.Users");
        }
    }
}
