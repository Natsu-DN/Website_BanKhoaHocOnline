namespace DACS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addALL : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChildContents",
                c => new
                    {
                        IDtitle = c.Int(nullable: false, identity: true),
                        TitleCon = c.String(),
                        Sourse = c.String(),
                    })
                .PrimaryKey(t => t.IDtitle);
            
            CreateTable(
                "dbo.ParentContents",
                c => new
                    {
                        IDtitle = c.Int(nullable: false, identity: true),
                        TitleCha = c.String(),
                    })
                .PrimaryKey(t => t.IDtitle);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ParentContents");
            DropTable("dbo.ChildContents");
        }
    }
}
