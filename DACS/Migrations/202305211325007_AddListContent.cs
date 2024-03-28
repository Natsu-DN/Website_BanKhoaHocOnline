namespace DACS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddListContent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "IDtitle", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "IDtitle");
        }
    }
}
