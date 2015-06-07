using System.Data.Entity.Migrations;

namespace Shared.Repository.Migrations
{
    public partial class Seeddb5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "ECTS", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "ECTS");
        }
    }
}
