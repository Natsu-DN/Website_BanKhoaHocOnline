namespace DACS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDetailID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "DetailID", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "DetailID");
        }
    }
}
