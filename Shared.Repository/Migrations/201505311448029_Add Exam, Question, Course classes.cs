namespace Shared.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExamQuestionCourseclasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Duration = c.Time(nullable: false, precision: 7),
                        Place = c.String(),
                        Course_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Courses", t => t.Course_ID)
                .Index(t => t.Course_ID);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Time = c.Time(nullable: false, precision: 7),
                        Text = c.String(nullable: false),
                        Points = c.Int(nullable: false),
                        Exam_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Exams", t => t.Exam_ID)
                .Index(t => t.Exam_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "Exam_ID", "dbo.Exams");
            DropForeignKey("dbo.Exams", "Course_ID", "dbo.Courses");
            DropIndex("dbo.Questions", new[] { "Exam_ID" });
            DropIndex("dbo.Exams", new[] { "Course_ID" });
            DropTable("dbo.Questions");
            DropTable("dbo.Exams");
            DropTable("dbo.Courses");
        }
    }
}
