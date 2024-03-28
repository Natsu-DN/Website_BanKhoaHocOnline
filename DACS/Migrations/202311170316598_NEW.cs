namespace DACS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NEW : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        LessonID = c.Int(nullable: false, identity: true),
                        LessonName = c.String(maxLength: 100),
                        Description = c.String(maxLength: 1000),
                        CourseID = c.Int(),
                    })
                .PrimaryKey(t => t.LessonID)
                .ForeignKey("dbo.Courses", t => t.CourseID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        VideoID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        VideoURL = c.String(maxLength: 50),
                        Duration = c.Time(nullable: false, precision: 7),
                        LessonID = c.Int(),
                    })
                .PrimaryKey(t => t.VideoID)
                .ForeignKey("dbo.Lessons", t => t.LessonID)
                .Index(t => t.LessonID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Videos", "LessonID", "dbo.Lessons");
            DropForeignKey("dbo.Lessons", "CourseID", "dbo.Courses");
            DropIndex("dbo.Videos", new[] { "LessonID" });
            DropIndex("dbo.Lessons", new[] { "CourseID" });
            DropTable("dbo.Videos");
            DropTable("dbo.Lessons");
        }
    }
}
