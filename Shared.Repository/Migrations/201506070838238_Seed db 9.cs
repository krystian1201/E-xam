using System.Data.Entity.Migrations;

namespace Shared.Repository.Migrations
{
    public partial class Seeddb9 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Courses", "ECTS");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "ECTS", c => c.Int(nullable: false));
        }
    }
}
