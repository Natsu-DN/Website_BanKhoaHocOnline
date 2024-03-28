namespace DACS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reset : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Videos", "LessonID", "dbo.Courses");
            AddForeignKey("dbo.Videos", "LessonID", "dbo.Lessons", "LessonID");
            DropColumn("dbo.Videos", "Des");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Videos", "Des", c => c.String());
            DropForeignKey("dbo.Videos", "LessonID", "dbo.Lessons");
            AddForeignKey("dbo.Videos", "LessonID", "dbo.Courses", "ID");
        }
    }
}
