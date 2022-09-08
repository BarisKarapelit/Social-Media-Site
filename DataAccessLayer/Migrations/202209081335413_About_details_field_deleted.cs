namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class About_details_field_deleted : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Abouts", "AboutDetails3");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Abouts", "AboutDetails3", c => c.String(maxLength: 1000));
        }
    }
}
