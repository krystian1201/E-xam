namespace Shared.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnotherMigration : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Questions", new[] { "ExamID" });
            AlterColumn("dbo.Questions", "ExamID", c => c.Int());
            CreateIndex("dbo.Questions", "ExamID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Questions", new[] { "ExamID" });
            AlterColumn("dbo.Questions", "ExamID", c => c.Int(nullable: false));
            CreateIndex("dbo.Questions", "ExamID");
        }
    }
}
