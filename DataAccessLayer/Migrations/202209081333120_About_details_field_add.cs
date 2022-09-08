namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class About_details_field_add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "AboutDetails3", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abouts", "AboutDetails3");
        }
    }
}
