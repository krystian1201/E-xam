using System.Data.Entity.Migrations;

namespace Shared.Repository.Migrations
{
    public partial class Seeddb3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Questions", "Points");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "Points", c => c.Int(nullable: false));
        }
    }
}
