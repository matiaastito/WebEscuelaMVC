namespace WebEscuelaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aulas",
                c => new
                    {
                        AulaId = c.String(nullable: false, maxLength: 128),
                        Numero = c.String(nullable: false),
                        Estado = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AulaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Aulas");
        }
    }
}
