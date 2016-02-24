namespace WatchMe.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClusteredIndexAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String(maxLength: 30));
            CreateIndex("dbo.Categories", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Categories", new[] { "Name" });
            AlterColumn("dbo.Categories", "Name", c => c.String());
        }
    }
}
