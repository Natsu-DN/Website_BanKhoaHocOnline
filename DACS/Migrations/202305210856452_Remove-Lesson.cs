namespace DACS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveLesson : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Lessons", "CourseID", "dbo.Courses");
            DropIndex("dbo.Lessons", new[] { "CourseID" });
            DropTable("dbo.Lessons");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        VideoURL = c.String(),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.Lessons", "CourseID");
            AddForeignKey("dbo.Lessons", "CourseID", "dbo.Courses", "ID", cascadeDelete: true);
        }
    }
}
