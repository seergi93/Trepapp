namespace Trepapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Escaladors",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Nom = c.String(),
                        Llinatge = c.String(),
                        Edat = c.Int(nullable: false),
                        CorreuElectronic = c.String()
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Escaladors");
        }
    }
}
