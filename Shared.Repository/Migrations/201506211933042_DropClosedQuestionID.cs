namespace Shared.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropClosedQuestionID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClosedAnswers", "ClosedQuestion_ID", "dbo.Questions");
            DropIndex("dbo.ClosedAnswers", new[] { "ClosedQuestion_ID" });
            DropIndex("dbo.ClosedAnswers", new[] { "ClosedQuestion_ID1" });
            //DropColumn("dbo.ClosedAnswers", "ClosedQuestionID");
            //DropColumn("dbo.ClosedAnswers", "ClosedQuestionID");
            //RenameColumn(table: "dbo.ClosedAnswers", name: "ClosedQuestion_ID1", newName: "ClosedQuestionID");
            //RenameColumn(table: "dbo.ClosedAnswers", name: "ClosedQuestion_ID", newName: "ClosedQuestionID");
            //AlterColumn("dbo.ClosedAnswers", "ClosedQuestionID", c => c.Int(nullable: false));
            //AlterColumn("dbo.ClosedAnswers", "ClosedQuestionID", c => c.Int(nullable: false));
            //AddColumn("dbo.ClosedAnswers", "ClosedQuestionID", c => c.Int(nullable: false));
            CreateIndex("dbo.ClosedAnswers", "ClosedQuestionID");
            //AddForeignKey("dbo.ClosedAnswers", "ClosedQuestionID", "dbo.Questions", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.ClosedAnswers", "ClosedQuestionID", "dbo.Questions");
            DropIndex("dbo.ClosedAnswers", new[] { "ClosedQuestionID" });
            //DropColumn("dbo.ClosedAnswers", "ClosedQuestionID");
            //AlterColumn("dbo.ClosedAnswers", "ClosedQuestionID", c => c.Int());
            //AlterColumn("dbo.ClosedAnswers", "ClosedQuestionID", c => c.Int());
            //RenameColumn(table: "dbo.ClosedAnswers", name: "ClosedQuestionID", newName: "ClosedQuestion_ID");
            //RenameColumn(table: "dbo.ClosedAnswers", name: "ClosedQuestionID", newName: "ClosedQuestion_ID1");
            //AddColumn("dbo.ClosedAnswers", "ClosedQuestionID", c => c.Int(nullable: false));
            //AddColumn("dbo.ClosedAnswers", "ClosedQuestionID", c => c.Int(nullable: false));
            //CreateIndex("dbo.ClosedAnswers", "ClosedQuestion_ID1");
            //CreateIndex("dbo.ClosedAnswers", "ClosedQuestion_ID");
            //AddForeignKey("dbo.ClosedAnswers", "ClosedQuestion_ID", "dbo.Questions", "ID");
        }
    }
}
