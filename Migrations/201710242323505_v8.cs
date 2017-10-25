namespace SalaoIedaV4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Agenda", "Cliente_idCliente", "dbo.Clientes");
            DropIndex("dbo.Agenda", new[] { "Cliente_idCliente" });
            RenameColumn(table: "dbo.Agenda", name: "Cliente_idCliente", newName: "idCliente");
            AlterColumn("dbo.Agenda", "idCliente", c => c.Int(nullable: false));
            CreateIndex("dbo.Agenda", "idCliente");
            AddForeignKey("dbo.Agenda", "idCliente", "dbo.Clientes", "idCliente", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Agenda", "idCliente", "dbo.Clientes");
            DropIndex("dbo.Agenda", new[] { "idCliente" });
            AlterColumn("dbo.Agenda", "idCliente", c => c.Int());
            RenameColumn(table: "dbo.Agenda", name: "idCliente", newName: "Cliente_idCliente");
            CreateIndex("dbo.Agenda", "Cliente_idCliente");
            AddForeignKey("dbo.Agenda", "Cliente_idCliente", "dbo.Clientes", "idCliente");
        }
    }
}
