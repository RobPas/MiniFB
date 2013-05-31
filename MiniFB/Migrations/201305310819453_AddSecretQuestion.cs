namespace MiniFB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSecretQuestion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserSecretQuestion", c => c.String());
            AddColumn("dbo.Users", "UserSecretAnswer", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "UserSecretAnswer");
            DropColumn("dbo.Users", "UserSecretQuestion");
        }
    }
}
