namespace SalaoIedaV4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Agenda", "idCliente", "dbo.Clientes");
            DropIndex("dbo.Agenda", new[] { "idCliente" });
            RenameColumn(table: "dbo.Agenda", name: "idCliente", newName: "Cliente_idCliente");
            AlterColumn("dbo.Agenda", "Cliente_idCliente", c => c.Int());
            CreateIndex("dbo.Agenda", "Cliente_idCliente");
            AddForeignKey("dbo.Agenda", "Cliente_idCliente", "dbo.Clientes", "idCliente");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Agenda", "Cliente_idCliente", "dbo.Clientes");
            DropIndex("dbo.Agenda", new[] { "Cliente_idCliente" });
            AlterColumn("dbo.Agenda", "Cliente_idCliente", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Agenda", name: "Cliente_idCliente", newName: "idCliente");
            CreateIndex("dbo.Agenda", "idCliente");
            AddForeignKey("dbo.Agenda", "idCliente", "dbo.Clientes", "idCliente", cascadeDelete: true);
        }
    }
}
