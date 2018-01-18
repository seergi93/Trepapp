namespace Trepapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Federat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Escaladors", "Federat", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Escaladors", "Federat");
        }
    }
}
