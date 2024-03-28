namespace DACS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveALL : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Courses", "IDtitle");
            DropTable("dbo.ChildContents");
            DropTable("dbo.ParentContents");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ParentContents",
                c => new
                    {
                        IDtitle = c.Int(nullable: false, identity: true),
                        TitleCha = c.String(),
                    })
                .PrimaryKey(t => t.IDtitle);
            
            CreateTable(
                "dbo.ChildContents",
                c => new
                    {
                        IDtitle = c.Int(nullable: false, identity: true),
                        TitleCon = c.String(),
                        Sourse = c.String(),
                    })
                .PrimaryKey(t => t.IDtitle);
            
            AddColumn("dbo.Courses", "IDtitle", c => c.Int());
        }
    }
}
