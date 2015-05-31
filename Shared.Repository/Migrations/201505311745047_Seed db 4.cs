namespace Shared.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seeddb4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "Points", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "Points");
        }
    }
}
