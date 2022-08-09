namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class xxx : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "WriterID", c => c.Int(nullable: false));
            CreateIndex("dbo.Contents", "WriterID");
            AddForeignKey("dbo.Contents", "WriterID", "dbo.Writers", "WriterID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contents", "WriterID", "dbo.Writers");
            DropIndex("dbo.Contents", new[] { "WriterID" });
            DropColumn("dbo.Contents", "WriterID");
        }
    }
}
