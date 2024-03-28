namespace DACS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDetailID : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Courses", "DetailID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "DetailID", c => c.Int());
        }
    }
}
