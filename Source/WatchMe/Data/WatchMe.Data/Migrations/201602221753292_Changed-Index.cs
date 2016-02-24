namespace WatchMe.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ChangedIndex : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Categories", new[] { "Name" });
            AlterColumn("dbo.Categories", "CategoryIdentifier", c => c.String(maxLength: 30));
            CreateIndex("dbo.Categories", "CategoryIdentifier", unique: true);
        }

        public override void Down()
        {
            DropIndex("dbo.Categories", new[] { "CategoryIdentifier" });
            AlterColumn("dbo.Categories", "CategoryIdentifier", c => c.String());
            CreateIndex("dbo.Categories", "Name", unique: true);
        }
    }
}