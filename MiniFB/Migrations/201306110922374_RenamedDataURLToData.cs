namespace MiniFB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedDataURLToData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewsFeedItems", "Data", c => c.String());
            DropColumn("dbo.NewsFeedItems", "DataURL");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NewsFeedItems", "DataURL", c => c.String());
            DropColumn("dbo.NewsFeedItems", "Data");
        }
    }
}
