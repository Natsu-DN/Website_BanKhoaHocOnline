namespace DACS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableCourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        Author = c.String(maxLength: 50),
                        Des = c.String(maxLength: 500),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.String(maxLength: 250),
                        CateID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CateID)
                .Index(t => t.CateID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "CateID", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "CateID" });
            DropTable("dbo.Courses");
            DropTable("dbo.Categories");
        }
    }
}
