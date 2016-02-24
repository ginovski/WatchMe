namespace WatchMe.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedIndexes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Actors", "FirstName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Actors", "LastName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Movies", "Title", c => c.String(maxLength: 100));
            CreateIndex("dbo.Actors", "FirstName");
            CreateIndex("dbo.Actors", "LastName");
            CreateIndex("dbo.Movies", "Title");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Movies", new[] { "Title" });
            DropIndex("dbo.Actors", new[] { "LastName" });
            DropIndex("dbo.Actors", new[] { "FirstName" });
            AlterColumn("dbo.Movies", "Title", c => c.String());
            AlterColumn("dbo.Actors", "LastName", c => c.String());
            AlterColumn("dbo.Actors", "FirstName", c => c.String());
        }
    }
}
