namespace MiniFB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewsFeedComments", "CommentWriter", c => c.String());
            DropColumn("dbo.NewsFeedComments", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NewsFeedComments", "UserID", c => c.Guid(nullable: false));
            DropColumn("dbo.NewsFeedComments", "CommentWriter");
        }
    }
}
