namespace DACS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLesson : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lessons", "CourseID", "dbo.Courses");
            DropIndex("dbo.Lessons", new[] { "CourseID" });
            DropTable("dbo.Lessons");
        }
    }
}
