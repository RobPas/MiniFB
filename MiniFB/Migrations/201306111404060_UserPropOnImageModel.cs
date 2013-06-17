namespace MiniFB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserPropOnImageModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "UserID", c => c.Guid(nullable: false));
            AddForeignKey("dbo.Images", "UserID", "dbo.Users", "ID", cascadeDelete: true);
            CreateIndex("dbo.Images", "UserID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Images", new[] { "UserID" });
            DropForeignKey("dbo.Images", "UserID", "dbo.Users");
            DropColumn("dbo.Images", "UserID");
        }
    }
}
