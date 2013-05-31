namespace MiniFB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataURLProp_On_NewsFeedItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewsFeedItems", "DataURL", c => c.String());
            AlterColumn("dbo.NewsFeedItems", "Content", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NewsFeedItems", "Content", c => c.String(maxLength: 250));
            DropColumn("dbo.NewsFeedItems", "DataURL");
        }
    }
}
