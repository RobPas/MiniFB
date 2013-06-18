namespace MiniFB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Images", "UserID", c => c.Guid(nullable: false));
            AddForeignKey("dbo.Images", "UserID", "dbo.Users", "ID", cascadeDelete: true);
            CreateIndex("dbo.Images", "UserID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Images", new[] { "UserID" });
            DropIndex("dbo.Likes", new[] { "NewsFeedItemID" });
            DropForeignKey("dbo.Images", "UserID", "dbo.Users");
            DropForeignKey("dbo.Likes", "NewsFeedItemID", "dbo.NewsFeedItems");
            DropColumn("dbo.Images", "UserID");
            DropTable("dbo.Likes");
        }
    }
}
