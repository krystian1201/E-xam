using System.Data.Entity.Migrations;

namespace Shared.Repository.Migrations
{
    public partial class Questionpointsfrominttodecimal : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE dbo.Questions DROP CONSTRAINT DF__Questions__Point__37A5467C");
            AddColumn("dbo.Questions", "TimeToRespond", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.Questions", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Questions", "Points", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Questions", "Time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "Time", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Questions", "Points", c => c.Int(nullable: false));
            DropColumn("dbo.Questions", "Discriminator");
            DropColumn("dbo.Questions", "TimeToRespond");
        }
    }
}
